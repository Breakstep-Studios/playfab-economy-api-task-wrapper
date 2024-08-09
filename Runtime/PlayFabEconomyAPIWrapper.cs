using System.Threading.Tasks;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.EconomyModels;
using ThomasBrown.PlayFab;

namespace BreakstepStudios.Scripts.Runtime.PlayFab
{
    public static class PlayFabEconomyAPIWrapper
    {
        /// <inheritdoc cref="PlayFabEconomyAPI.RedeemGooglePlayInventoryItems"/>
        public static Task<PlayFabCommonResponse<RedeemGooglePlayInventoryItemsResponse>> RedeemGooglePlayInventoryItemsAsync(RedeemGooglePlayInventoryItemsRequest request)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabCommonResponse<RedeemGooglePlayInventoryItemsResponse>>();
            PlayFabEconomyAPI.RedeemGooglePlayInventoryItems(request,
                (result) =>
                {
                    taskCompletionSource.SetResult(new PlayFabCommonResponse<RedeemGooglePlayInventoryItemsResponse>(result,null));
                },
                (error) =>
                {
                    taskCompletionSource.SetResult(new PlayFabCommonResponse<RedeemGooglePlayInventoryItemsResponse>(null,error));
                }
            );
            return taskCompletionSource.Task;
        }
        
    }
}