function ControlActions() {

    this.URL_API = "http://localhost:53405/api";

    this.GetUrlApiService = function (service) {
        return this.URL_API + service;
    }

    this.FillTable = function () {

    }

    this.GetData = function () {
        $.ajax({});
    }
}