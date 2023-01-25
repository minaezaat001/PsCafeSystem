// Window Loding
window.onload = function () {
    document.querySelector(".load-page").remove();
 
};

$(function () {
   



    // Set Padding Bottom In Body
    if ($("footer").hasClass("bottom")) {
        $(".app").css("paddingBottom", $("footer").innerHeight());
        $(".app").css("paddingLeft", $(".header .nav-bar").innerWidth());
    }
    // End Set Padding

    // Start Function Show Sections
    $(".link-navbar").click(function (e) {
        e.preventDefault();
        $(this).addClass("active");
        $(this).parent().siblings().children().removeClass("active");

        $(".block").hide();
        $($(this).data("targets")).addClass("block").siblings().removeClass("block");
        $($(this).data("targets")).fadeIn("slow");
    });
    // End Function Show Sections

    // Start Function Toggle Show PS & Drink
    // Show Dirnk Add
    $(".add-drink-form").click(function () {
        $(".add-drink-page").fadeIn();
        $(".add-drink-page").siblings(".add-ps-page, .add-user-page,.add-tpye-ps ").hide();
    });

    // Show PS Add
    $(".add-ps").click(function () {
        $(".add-ps-page").fadeIn();
        $(".add-ps-page").siblings(".add-drink-page, .add-user-page,.add-tpye-ps ").hide();
    });

    // Show Add User
    $(".add-user").click(function () {
        $(".add-user-page").fadeIn();
        $(".add-user-page").siblings(".add-ps-page, .add-drink-page,.add-tpye-ps ").hide();
    });

    // Show PS Add
    $(".add-ps-type").click(function () {
        $(".add-tpye-ps").fadeIn();
        $(".add-tpye-ps").siblings(".add-ps-page, .add-user-page,.add-drink-page ").hide();
    });

    $(".update").click(function () {
        $(this).parent().parent().parent().parent().parent().siblings("form").hide();
        $(this).parent().parent().parent().parent().parent().siblings("form.hideen").fadeIn();
    });

    // End Function Toggle Show PS & Drink

    // Start Function Popup Drink
    $(".add-drink").click(function () {
        const numPs = $(this).parent().parent().parent().parent().children(".card-title").children(".icons-card").children(".num-ps").text();
        $(this).parent().parent().parent().siblings(".parent-popup-drink").children(".popup-content-drink").children("form").children(".set-num-ps").val(numPs);
        console.log($(this).parent().parent().parent().siblings(".parent-popup-drink"));
        $(this).parent().parent().parent().siblings(".parent-popup-drink").fadeIn();
        $(".popup-content-drink").css("transform", "scale(1) translate(-50%, -50%)");
    });
    // Hide Popup For Click To Parent Popup
    $(".parent-popup-drink").click(function () {
        $(this).fadeOut();
        $(".popup-content-drink").css("transform", "scale(0) translate(-50%, -50%)");
    });
    // Stop Hide && In Content Click
    $(".popup-content-drink").click(function (e) {
        e.stopPropagation();
    });
    // Closed Popup From Icon
    $(".parent-popup-drink .icon-closed").click(function (e) {
        e.preventDefault();
        $(".parent-popup-drink").fadeOut();
        $(".popup-content-drink").css("transform", "scale(0) translate(-50%, -50%)");
    });
    // Closed Popup From Key ESC
    $(document).keydown(function (e) {
        if (e.keyCode === 27) {
            $(".parent-popup-drink").fadeOut();
            $(".popup-content-drink").css("transform", "scale(0) translate(-50%, -50%)");
        }
    });
    // End Function Popup Drink

    // Start Function Popup Details
    // Show PopUp Fuinctios Drink
    $(".details").click(function () {
        const numPs = $(this).parent().parent().parent().parent().children(".card-title").children(".icons-card").children(".num-ps").text();
        const setData = $(this).parent().parent().parent().siblings(".parent-popup-details").children(".popup-content-details").children("form").children(".set-num-ps").val(numPs);
        $(this).parent().parent().parent().siblings(".parent-popup-details").fadeIn();
        $(".popup-content-details").css("transform", "scale(1) translate(-50%, -50%)");
    });
    // Hide Popup For Click To Parent Popup
    $(".parent-popup-details").click(function () {
        $(this).fadeOut();
        $(".popup-content-details").css("transform", "scale(0) translate(-50%, -50%)");
    });
    // Stop Hide && In Content Click
    $(".popup-content-details").click(function (e) {
        e.stopPropagation();
    });
    // Closed Popup From Icon
    $(".parent-popup-details .icon-closed").click(function (e) {
        e.preventDefault();
        $(".parent-popup-details").fadeOut();
        $(".popup-content-details").css("transform", "scale(0) translate(-50%, -50%)");
    });
    // Closed Popup From Key ESC
    $(document).keydown(function (e) {
        if (e.keyCode === 27) {
            $(".parent-popup-details").fadeOut();
            $(".popup-content-details").css("transform", "scale(0) translate(-50%, -50%)");
        }
    });
    // End Function Popup Details

    // Toggle PopUp
    $('.shift-btn-today').click(function () {
        $('.today-shift').hide();
        $('.shfit-all').fadeIn();
    })

    $('.shift-btn-all').click(function () {
        $('.today-shift').fadeIn();
        $('.shfit-all').hide();
    })
});
