window.AzureMap = {
    map: null,
    LoadMap: function(subKey)
    {
        this.map = new atlas.Map("mapContainer", {
            authOptions:{
                authType: 'subscriptionKey',
                subscriptionKey: subKey
            },
            style: 'night'
        });
    }
}