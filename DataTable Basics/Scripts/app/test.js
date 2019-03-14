$(document).ready(function () {
    $.ajax({
        url: 'Home/GetCampaigns',
        method: 'post',
        dataType: 'json',
        success: function (data) {
            $('#data-table-test').dataTable({
                data: data,
                'scrollY':400,
                columns: [
                    { 'data': 'Id' },
                    { 'data': 'Name' },
                    {
                        'data': 'CreatedAt',
                        //'render': function (jsonDate) {
                        //   return moment(jsonDate, "MM-DD-YYYY");
                        //},
                        'searchable': false,
                        'sortable':false
                    },

                ]
            });
        }
    });
})