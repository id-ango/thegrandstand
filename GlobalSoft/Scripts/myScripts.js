var Categories = []

 
$(document).ready(function () {
    //Add button click event
    $('#add').click(function () {
        //validation and add order items
       
        
        var isAllValid = true;
        if ($('#TransNoID').val() == "0") {
            isAllValid = false;
            $('#TransNoID').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#TransNoID').siblings('span.error').css('visibility', 'hidden');
           
        }
 
        if ($('#Keterangan').val().Trim() != '') {
            isAllValid = false;
            $('#Keterangan').siblings('span.error').css('visibility', 'visible');
            alert("Testomg");
        }
        else {
            $('#Keterangan').siblings('span.error').css('visibility', 'hidden');
            alert("keterangan");
        }
 
        if (!($('#Terima').val().trim() != '' && (parseInt($('#Terima').val()) || 0))) {
            isAllValid = false;
            $('#Terima').siblings('span.error').css('visibility', 'visible');
            alert("ketegan");
        }
        else {
            $('#Terima').siblings('span.error').css('visibility', 'hidden');
            alert("Tesee");
        }
 
        if (!($('#Bayar').val().trim() != '' && !isNaN($('#Bayar').val().trim()))) {
            isAllValid = false;
            $('#Bayar').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#Bayar').siblings('span.error').css('visibility', 'hidden');
        }
 
        if (isAllValid) {
            var $newRow = $('#mainrow').clone().removeAttr('id');
            $('.pc', $newRow).val($('#TransNoID').val());
 
            //Replace add button with remove button
            $('#add', $newRow).addClass('remove').val('Remove').removeClass('btn-success').addClass('btn-danger');
 
            //remove id attribute from new clone row
            $('#TransNoID,#Keterangan,#Terima,#Bayar,#add', $newRow).removeAttr('id');
            $('span.error', $newRow).remove();
            //append clone row
            $('#orderdetailsItems').append($newRow);
 
            //clear select data
            $('#TransNoID').val('0');
            $('#Keterangan').val('');
            $('#Terima,#Bayar').val('');
            $('#orderItemError').empty();
        }
 
    })
 
    //remove button click event
    $('#orderdetailsItems').on('click', '.remove', function () {
        $(this).parents('tr').remove();
    });
 
    $('#submit').click(function () {
        var isAllValid = true;
 
        //validate order items
        $('#orderItemError').text('');
        var list = [];
        var errorItemCount = 0;
        $('#orderdetailsItems tbody tr').each(function (index, ele) {
            if (
                $('select.TransNoID', this).val() == "0" ||
                (parseInt($('.Terima', this).val()) || 0) == 0 ||
                $('.Bayar', this).val() == "" ||
                isNaN($('.Bayar', this).val())
                ) {
                errorItemCount++;
                $(this).addClass('error');
            } else {
                var orderItem = {
                    TransNoID: $('select.TransNoID', this).val(),
                    Terima: parseInt($('.Terima', this).val()),
                    Bayar: parseFloat($('.Bayar', this).val())
                }
                list.push(orderItem);
            }
        })
 
        if (errorItemCount > 0) {
            $('#orderItemError').text(errorItemCount + " invalid entry in order item list.");
            isAllValid = false;
        }
 
        if (list.length == 0) {
            $('#orderItemError').text('At least 1 order item required.');
            isAllValid = false;
        }
 
        if ($('#Docno').val().trim() == '') {
            $('#Docno').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#Docno').siblings('span.error').css('visibility', 'hidden');
        }
 
        if ($('#Tanggal').val().trim() == '') {
            $('#Tanggal').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#Tanggal').siblings('span.error').css('visibility', 'hidden');
        }
 
        if (isAllValid) {
            var data = {
                Docno: $('#Docno').val().trim(),
                Tanggalg: $('#Tanggal').val().trim(),
                Keterangan: $('#Description').val().trim(),
                OrderDetails: list
            }
 
            $(this).val('Please wait...');
 
            $.ajax({
                type: 'POST',
                url: '/TransBank/save',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function (data) {
                    if (data.status) {
                        alert('Successfully saved');
                        //here we will clear the form
                        list = [];
                        $('#Docno,#Tanggal,#Description').val('');
                        $('#orderdetailsItems').empty();
                    }
                    else {
                        alert('Error');
                    }
                    $('#submit').text('Save');
                },
                error: function (error) {
                    console.log(error);
                    $('#submit').text('Save');
                }
            });
        }
 
    });
 
});
 
