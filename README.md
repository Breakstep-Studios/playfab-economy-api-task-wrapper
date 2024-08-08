# PlayFab Economy API Task Wrapper
The PlayFab economy API Task wrapper wraps the Unity economy API to convert the async callback pattern to task async await pattern.

### Usage Note
In most cases it would be preferrable to utilize the [PlayFab C# SDK](https://docs.microsoft.com/en-us/gaming/playfab/sdks/c-sharp/) ([Additional notes here](https://community.playfab.com/questions/47743/unity-stripping-doesnt-work-on-low-setting.html)) within Unity. This tool is most beneficial for projects that have already gone the Unity SDK route and are looking to gradually move code base to async await pattern. 

# Quick Start
Add the following line to your Unity package `Packages/manifest.json`
```json
{
  "dependencies": {
    "com.breakstepstudios.playfab-economy-api-task-wrapper": "https://github.com/Breakstep-Studios/playfab-economy-api-task-wrapper.git#release",
  }
}
```
# Examples
### Example Conversion
```csharp
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
```

### Example Usage
```csharp
public async PlayFabCommonResponse<RedeemGooglePlayInventoryItemsResponse> RedeemGooglePlayInventoryItems()
{
    var redeemGooglePlayInventoryItemsRequest = new RedeemGooglePlayInventoryItemsRequest
    {
        CollectionId = "MyCollection"
    };
    var result = await PlayFabEconomyAPIWrapper.RedeemGooglePlayInventoryItemsAsync(getTitleDataRequest);
    if (result.ContainsError)
    {
        return result;
    }
}
```
# TODO
- [ ] This package currently relies on [playfab-client-api-task-wrapper](https://github.com/Breakstep-Studios/playfab-client-api-task-wrapper). This dependency is only due to the fact that `playfab-client-api-task-wrapper` defines some data models this repo relies/will rely on. In the long run it would more beneficial to pull those data models in to a seperate repo that both the client & economy api rely on. For example something like `playfab-core-api-task-wrapper`.
