using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Taoyuan_Traffic.Models.Postman;

namespace Taoyuan_Traffic.Controllers.V1.Postman
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class PostmanController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var collection = Configuration.Properties.GetOrAdd(
                "postmanCollection", k =>
                {
                    var requestUri = Request.RequestUri;
                    string baseUri = requestUri.Scheme + "://" + requestUri.Host + ":" + requestUri.Port +
                                     HttpContext.Current.Request.ApplicationPath;

                    var postManCollection = new PostmanCollection();
                    postManCollection.Id = Guid.NewGuid();
                    postManCollection.Name = "ASP.NET Web API Service";
                    postManCollection.Timestamp = DateTime.Now.Ticks;
                    postManCollection.Requests = new Collection<PostmanRequest>();

                    foreach (var apiDescription in Configuration.Services.GetApiExplorer().ApiDescriptions)
                    {
                        var request = new PostmanRequest
                        {
                            CollectionId = postManCollection.Id,
                            Id = Guid.NewGuid(),
                            Method = apiDescription.HttpMethod.Method,
                            Url = baseUri.TrimEnd('/') + "/" + apiDescription.RelativePath,
                            Description = apiDescription.Documentation,
                            Name = apiDescription.RelativePath,
                            Data = "",
                            Headers = "",
                            DataMode = "params",
                            Timestamp = 0
                        };
                        postManCollection.Requests.Add(request);
                    }
                    return postManCollection;
                }) as PostmanCollection;

            return Request.CreateResponse<PostmanCollection>(HttpStatusCode.OK, collection, "application/json");
        }
    }
}
