# Photo Describer

A simple Xamarin app to describe photos using the Azure computer vision service. This was written during an introduction to Xamarin session at Imperial College London, the slides for which are included in the [Slides](./Slides) folder.

This app uses the [Xamarin Media Plugin](https://www.nuget.org/packages/Xam.Plugin.Media/) to take a photo, then the [Azure Computer Vision Service](https://docs.microsoft.com/azure/cognitive-services/computer-vision/home/?WT.mc_id=imperial-github-jabenn) to generate a description.

## To use this app

1. Head to the [Azure Cognitive Services](https://azure.microsoft.com/en-gb/services/cognitive-services/computer-vision/) site and click the __Try the Computer Vision API__ button.
2. Log in with an appropriate provider, and get an API key.
3. Open the solution and head to the `MainViewModel` class in the `PhotoDescriber` project. In the constructor where the `ApiKeyServiceClientCredentials` is created, change `<your key here>` to your API key.
