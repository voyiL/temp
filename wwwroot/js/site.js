console.log("works");
window.onload = function () {

     const btnprint = document.getElementById('PrintBTn');
     console.log("works");
    }
    btnprint.addEventListener("click", printpage);

function printpage() {
    document.getElementById('sidebar').style.visibility = "hidden"
    document.getElementById('NavbarSide').style.visibility = "hidden";
    btnprint.style.visibility = "hidden";
    window.print();
    document.getElementById('sidebar').style.visibility = "visible"
    document.getElementById('NavbarSide').style.visibility = "visible";
    btnprint.style.visibility = "visible";

}

document.addEventListener('DOMContentLoaded', function () {
    
    var hasRegistered = true;

    
    if (hasRegistered) {
        var modal = new bootstrap.Modal(document.getElementById("myModal"));
        modal.show();

        
        var closeButton = document.getElementById("close");
        closeButton.addEventListener("click", function () {
            modal.hide();
        });
    }
    //Tempdata

    setTimeout(function () {
        var tempdat = document.getElementById('tempdata');

        if (tempdat) {
            tempdat.remove();
            tempdat.textContent = '';
        }
    }, 5000);

});