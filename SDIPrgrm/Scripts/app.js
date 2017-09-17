
    $(document).ready(function () {
        $("#TxtFName").focus();
    $("#TxtFName").blur(function () {
                var name = $('#TxtFName').val();
                if (name.length == 0) {
        $("#fspan").show();
    } else {
        $("#fspan").hide();
    return true;
                }
            });

            var validGPA = document.getElementById('TxtGPA');
            validGPA.addEventListener('blur', myFunc);

            function myFunc(e) {
                var val = this.value;

                var re1 = /^([0-3]\.\d|4\.0)$/;

                    val = re1.exec(val);
                    if (!val) {

        this.value = "";
    $("#gpaspan").show();
                        return false;
                    }
                    else {
        $("#gpaspan").hide();
    returntrue;
                    }

            }

            $(document).on("submit", "form", function (e) {
               
                if ($("#TxtFName").val() == '') {
        e.preventDefault();

    return false;
                }
                else
                {
                    return true;
                }
            });
        });

   