$(document).ready(function () {
    var id = 0;
    // Start Timer Function
    $(".start").click(function () {
        let cuontUp = "interval" + id++,
            conutDown = "interval" + id++;
        // Set Vars
        const s = $(this)
                .parent(".input-wrapper")
                .siblings(".timer")
                .children(".clock-wrapper")
                .children(".seconds"),
            m = $(this)
                .parent(".input-wrapper")
                .siblings(".timer")
                .children(".clock-wrapper")
                .children(".minutes"),
            h = $(this)
                .parent(".input-wrapper")
                .siblings(".timer")
                .children(".clock-wrapper")
                .children(".hours"),
            input = $(this).siblings(".num");
        let seconds = 0,
            minutes = 0,
            hours = 0;

        // Checked For Value Inpu
        if (input.val() == "") {
            // Show Btns Actions
            $(this).parent().slideUp(350);
            $(this).parent().siblings().children(".reset-timer").hide(350);
            setTimeout(() => {
                $(this).parent().siblings().fadeIn(350);
                $(this).parent().siblings(".ps-chouse").hide();
                $(this).parent().siblings(".checked-box").hide();
                $(this).parent().siblings().children(".details ,.add-drink ,.stop-timer").fadeIn(350);
            }, 350);

            // Start Timer Up
            cuontUp = setInterval(() => {
                s.text() < 9 ? s.text("0" + seconds++) : parseInt(s.text(seconds++));
                m.text() < 9 ? m.text("0" + minutes) : parseInt(m.text(minutes));
                h.text() < 9 ? h.text("0" + hours) : parseInt(h.text(hours));

                // Mintes Counts
                if (seconds >= 60) {
                    seconds = 0;
                    m.text() < 9 ? m.text("0" + minutes++) : parseInt(m.text(minutes++));
                }

                // Hours Counts
                if (minutes >= 60) {
                    h.text() < 9 ? h.text("0" + hours++) : parseInt(h.text(hours++));
                    minutes = 0;
                    seconds = 0;
                }
            }, 1000);
            // End Timer Up
        } else {
            // Start Timer Down
            if (Math.round(input.val()) < 1) {
                swal("Your Can`t Add This Value");
            } else {
                // Show Btns Actions
                $(this).parent().slideUp(350);
                setTimeout(() => {
                    $(this).parent().siblings().fadeIn(350);
                    $(this).parent().siblings(".ps-chouse").hide();
                    $(this).parent().siblings(".checked-box").hide();

                    $(this)
                        .parent()
                        .siblings()
                        .children(".details ,.add-drink,.stop-timer")
                        .fadeIn(350);
                }, 350);

                // Post Timer Down Form Input Value
                let houre = 0,
                    min,
                    scen = 59;

                if (input.val() > 60) {
                    h.text(++houre <= 10 ? "0" + houre : houre);
                    min = input.val() - 60;
                    m.text(min-- <= 10 ? "0" + min-- : min--);
                } else {
                    min = Math.round(input.val());
                    m.text(min-- <= 10 ? "0" + min-- : min--);
                }
                // Start Timer Down
                conutDown = setInterval(() => {
                    s.text(scen);
                    s.text() <= 9
                        ? s.text("0" + scen--)
                        : parseInt(s.text(scen--));

                    if (min == -1 && scen < 0 && houre != 0) {
                        h.text(--houre);
                        min = 59;
                    }
                    // Down Seconds
                    if (scen < 0) {
                        m.text() < 10 > 1
                            ? m.text("0" + min--)
                            : parseInt(m.text(min--));
                        scen = 59;
                    }

                    // Finshed Time
                    if (m.text() == -1 && h.text() == 0 && s.text() == 0) {
                        s.text("00");
                        m.text("00");
                        h.text("00");
                       
                        $(this)
                            .parent()
                            .siblings()
                            .children(".add-drink")
                            .hide();
                        clearInterval(conutDown);
                        setTimeout(() => {
                            document.getElementById("finished").play();
                            swal("Ps  " + $(this).parent().parent().parent('.clock').siblings(".card-title").children('.icons-card').children('.num-ps').text()
                                + "  Time Up");
                        }, 1000);
                    }
                }, 1000);
            }
        }

        // Start Reset Timer Function
        $(this)
            .parent(".input-wrapper")
            .siblings(".buttons-wrapper")
            .children(".reset-timer")
            .click(function () {
                $(this).parent(".buttons-wrapper").hide();
                $(this).hide();
                $(this).parent(".buttons-wrapper").siblings(".timer").hide();
                $(this)
                    .parent(".buttons-wrapper")
                    .siblings(".input-wrapper")
                    .slideDown();
                $(this).parent().siblings(".ps-chouse").fadeIn(350);
                $(this).parent().siblings(".checked-box").fadeIn(350);
                // Reset Value In Timer
                s.text("00");
                m.text("00");
                h.text("00");
                input.val("");
                clearInterval(cuontUp);
                clearInterval(conutDown);
            });

        // Btn Stop Timer Function
        $(this)
            .parent(".input-wrapper")
            .siblings(".buttons-wrapper")
            .children(".stop-timer")
            .click(function () {
                clearInterval(cuontUp);
                $(this).hide();
                $(this).siblings(".add-drink").hide();
                $(this).siblings(".reset-timer").fadeIn(350);
            });

        // End Stop Timer Function
    });
    // End Timer Function

    // Checked For Box
    $(".checked-box input").click(function () {
        
        $(this).addClass("checked");
        $(this).siblings().removeClass("checked");

        if ($(this).hasClass("checked")) {
            $(this)
                .parent()
                .parent(".checked-box")
                .siblings(".input-wrapper")
                .children("button")
                .removeClass("no-clicked");  

        }
    });
});
 