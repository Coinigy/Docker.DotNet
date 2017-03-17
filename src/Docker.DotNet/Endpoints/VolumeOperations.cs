
namespace Docker.DotNet
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Models;

    internal class VolumeOperations : IVolumeOperations
    {
        internal static readonly ApiResponseErrorHandlingDelegate NoSuchVolumeHandler = (statusCode, responseBody) =>
        {
            if (statusCode == HttpStatusCode.NotFound)
            {
                throw new DockerNetworkNotFoundException(statusCode, responseBody);
            }
        };

        private readonly DockerClient _client;

        internal VolumeOperations(DockerClient client)
        {
            this._client = client;
        }
    

        public async Task<VolumeResponse> CreateVolumeAsync(VolumesCreateParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            var data = new JsonRequestContent<VolumesCreateParameters>(parameters, this._client.JsonSerializer);
            var response = await this._client.MakeRequestAsync(this._client.NoErrorHandlers, HttpMethod.Post, "volumes/create", null, data).ConfigureAwait(false);
            return this._client.JsonSerializer.DeserializeObject<VolumeResponse>(response.Body);
        }

        public Task RemoveVolumeAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            return this._client.MakeRequestAsync(new[] { NoSuchVolumeHandler }, HttpMethod.Delete, $"volumes/{id}", null);
        }

    

        public async Task<VolumeResponse> InspectVolumeAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            var response = await this._client.MakeRequestAsync(new[] { NoSuchVolumeHandler }, HttpMethod.Get, $"volumes/{id}", null).ConfigureAwait(false);
            return this._client.JsonSerializer.DeserializeObject<VolumeResponse>(response.Body);
        }

        public async Task<VolumesListResponse> ListVolumesAsync(VolumesListParameters parameters)
        {
            var queryParameters = parameters == null ? null : new QueryString<VolumesListParameters>(parameters);
            var response = await this._client.MakeRequestAsync(this._client.NoErrorHandlers, HttpMethod.Get, "volumes", queryParameters).ConfigureAwait(false);
            return this._client.JsonSerializer.DeserializeObject<VolumesListResponse>(response.Body);
        }
    }
}
