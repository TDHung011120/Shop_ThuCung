var user = {
    init: function () {
        user.registerEvents();
    },
    registerEvents: function () {
        $('.change-id').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/User/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response)
                    if (response.status == true) {
                        btn.text = "Kích Hoạt";
                    }
                    else {
                        btn.text = "Khóa";
                    }
                }

            })
        })
    }
}