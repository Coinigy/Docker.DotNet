
namespace Docker.DotNet
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IVolumeOperations
    {
        Task<VolumesListResponse> ListVolumesAsync(VolumesListParameters parameters = null);
        Task<VolumeResponse> CreateVolumeAsync(VolumesCreateParameters parameters);
        Task RemoveVolumeAsync(string id);
        Task<VolumeResponse> InspectVolumeAsync(string id);

        //Task Prune(IDictionary<string, IDictionary<string, bool>> filters = null);
    }
}
