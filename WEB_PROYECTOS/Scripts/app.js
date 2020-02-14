﻿function LoadingOverlayShow(id) {
    $(id).LoadingOverlay("show", {
        color: "rbga(255,255,255,0.5)",
        image: "/Content/loading.gif",
        imageResizeFactor: 0.6
    });
}

function LoadingOverlayHide(id) {
    $(id).LoadingOverlay("hide");
}

function ValidarFechas(dateIni, dateFin) {
    var _dateIni = new Date(dateIni);
    var _dateFin = new Date(dateFin);

    if (_dateFin < _dateIni)
        return false;
    else
        return true;
}

