using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using ProxyBanken.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProxyBanken.Helper
{
    public static class ProxyHelper
    {
        public static IList<Proxy> StartCrawler(ProxyProvider provider)
        {
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(provider.Url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html.Result);

            var proxyList = htmlDocument.DocumentNode.SelectNodes(provider.RowQuery);

            List<Proxy> proxies = proxyList.Select(proxyItem => new Proxy
            {
                Ip = GetIp(proxyItem.SelectSingleNode($".{provider.IpQuery}").InnerText), // get ip from table list
                Port = int.Parse(proxyItem.SelectSingleNode($".{provider.PortQuery}").InnerText.Trim()) // get port from table list
            }).ToList();

            Parallel.ForEach(proxies, proxy =>
            {
                var pingDate = Ping(proxy.Ip);
                if (pingDate.HasValue)
                {
                    proxy.LastFunctionalityTestDate = pingDate.Value;
                }


            });

            //CheckConnectivity("80.25.87.49", 47478, "www.google.com");
            return proxies;
        }

        public static DateTime? Ping(string address)
        {
            Ping ping = new Ping();

            try
            {
                PingReply reply = ping.Send(address, 2000);
                if (reply != null && reply.Status == IPStatus.Success)
                {
                    return DateTime.Now;
                }
            }
            catch
            {
                // ignored
            }

            return null;
        }

        public static string GetUserIP(HttpContext context)
        {

            return context.Connection.RemoteIpAddress.ToString();
        }

        public static DateTime? CheckConnectivity(string ip, int port, string testAddress)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(testAddress);
                request.Method = "GET";
                request.Timeout = 4000;
                WebProxy proxy = new WebProxy(ip, port)
                {
                    BypassProxyOnLocal = false
                };

                request.Proxy = proxy;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return DateTime.Now;
                }
            }
            catch (Exception exception)
            {
                // ignored
            }

            return null;


        }
        private static string GetIp(string ipString)
        {
            try
            {
                Regex ipAd = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
                MatchCollection matchResult = ipAd.Matches(ipString);
                return matchResult[0].Value;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public static IList<ProxyTest> TestProxies(IList<Proxy> proxyList, IEnumerable<ProxyTestUrl> getTestUrls)
        {
            var proxyTestList = new List<ProxyTest>();

            Parallel.ForEach(proxyList, proxy =>
            {
                Parallel.ForEach(getTestUrls, testUrl =>
                {
                    var testDateTime = CheckConnectivity(proxy.Ip, proxy.Port, testUrl.Url);
                    proxyTestList.Add(new ProxyTest
                    {
                        ProxyTestUrlId = testUrl.Id,
                        ProxyId = proxy.Id,
                        LastSuccessDate = testDateTime
                    });
                });
            });

            return proxyTestList;
        }
    }
}
