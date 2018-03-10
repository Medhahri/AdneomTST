
var ViewModel = function () {
    //Make the self as 'this' reference
    var self = this;
    //Declare observable which will be bind with UI
    self.Caffee = ko.observableArray();
    self.TypeCaffees = ko.observableArray();
    self.error = ko.observable();

    self.newCaffee = {
        TypeCaffee: ko.observable().extend({ required: "Merci de choisir un type !", logChange: "requered type" }),
        Sucre: ko.observable(2),
        UseMug: ko.observable(UseMug)
    }

    var cafeUri = '/api/Cafe/';
    var lastCafeUri = '/api/LastCafe/';
    var typeCafeUri = '/api/TypeCafe/';


    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getLastCaffee() {
        ajaxHelper(lastCafeUri, 'GET').done(function (data) {
            self.Caffee(data);
        });
    }

    function getTypeCaffee() {
        ajaxHelper(typeCafeUri, 'GET').done(function (data) {
            self.TypeCaffees(data);
        });
    }

    self.addCaffee = function (formElement) {
        if (self.newCaffee.TypeCaffee.isValid()) {

           var caffee = {
               IdType: self.newCaffee.TypeCaffee().Id,
               TypeCaffee: self.newCaffee.TypeCaffee().TypeDescription,
               Sucre: self.newCaffee.Sucre(),
               UseMug: self.newCaffee.UseMug()
           };

           ajaxHelper(cafeUri, 'POST', caffee).done(function (item) {
                self.Caffee(caffee);
            });
        }
        else {
            alert('Merci de choisir un type !');
        }
        
    }

    // Fetch the initial data.
    getLastCaffee();
    getTypeCaffee();
};

ko.applyBindings(new ViewModel());