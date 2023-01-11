
$(document).ready(function () {

    async function fetchCity() {
        let url = 'https://ipinfo.io/json?token=60d5f55d7e0c7f';
        let resp = await fetch(url);
        let data = await resp.json();
        let city = data.city;       
        var lang = "en";
        if (city != null && city != 'undefined') {
            var linkUrl = "https://weatherapi.dreammaker-it.se/forecast?city=" + city + "&lang=" + lang;
            requestData(linkUrl);
        }
        else {
            city = "LinkÖping";
            var linkUrl = "https://weatherapi.dreammaker-it.se/forecast?city=" + city + "&lang=" + lang;
            requestData(linkUrl);
        }

    }
    async function requestData(linkUrl) {
        const res = await fetch(linkUrl);
        const data = await res.json();
        $("#WeatherCount").html(data.temperatureC + "℃");
        $("#WeatherCity").html(data.city);
        $("#weatherImage").attr("src", data.icon.url);
        $("#WeatherSummary").html(data.summary);
    }
    fetchCity();
});