using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableManager : MonoBehaviour
{
    public DieManager dieManager; // refrence to dieManger to assign the Die Images List 
    public SpriteRenderer chip;   //  refrence to the Ship SpriteRenderer to assign the ShipImage ;
    public string playerImageAddress;       
    public List<string> DieImagesAdersses; 

   
    void Start()
    {
        // Load player image
        LoadImage(playerImageAddress);

        // Load DieImages
        foreach (string address in DieImagesAdersses)
        {
            LoadImage(address);
        }
    }

    void LoadImage(string address)
    {
        AsyncOperationHandle<Sprite> handle = Addressables.LoadAssetAsync<Sprite>(address);
        handle.Completed += (operationHandle) => OnImageLoaded(address, operationHandle);
    }

    void OnImageLoaded(string address, AsyncOperationHandle<Sprite> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            Sprite loadedImage = handle.Result;

            Debug.Log("" + address+"Loaded");
            
            if (address == playerImageAddress)
            {
                chip.sprite = loadedImage;                    // assign the LoadedImage To The chip
                Debug.Log("player sprite Loaded");
            }
            else
            {
                dieManager.DieImages.Add(loadedImage);          // fill the DieImages List
            }
        }
        else
        {
            Debug.LogError("Failed to load image: " + handle.DebugName);
        }
    }
}


