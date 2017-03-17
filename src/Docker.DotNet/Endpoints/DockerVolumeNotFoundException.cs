using System.Net;

namespace Docker.DotNet
{
    public class DockerVolumeNotFoundException : DockerApiException
    {
        public DockerVolumeNotFoundException(HttpStatusCode statusCode, string responseBody) : base(statusCode, responseBody)
        {
        }
    }
}