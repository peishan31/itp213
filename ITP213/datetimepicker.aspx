<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="datetimepicker.aspx.cs" Inherits="ITP213.datetimepicker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
      <label for="selectDateTime">Datetime</label>
        
    </div>

    <script>
        /* Brazilian initialisation for the jQuery UI date picker plugin. */
        /* Written by Leonildo Costa Silva (leocsilva@gmail.com). */
        (function (factory) {
            if (typeof define === "function" && define.amd) {

                // AMD. Register as an anonymous module.
                define(["../datepicker"], factory);
            } else {

                // Browser globals
                factory(jQuery.datepicker);
            }
        }(function (datepicker) {

            datepicker.regional['SG'] = {
                closeText: 'Confirm',
                prevText: '&#x3C;Previous',
                nextText: 'Next&#x3E;',
                currentText: 'Hoje',
                monthNames: ['January', 'February', 'March', 'April', 'March', 'June',
                'July', 'August', 'September', 'October', 'November', 'December'],
                monthNamesShort: ['Jan', 'Feb', 'Mar', 'Apr', 'Mar', 'Jun',
                'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
                dayNames: ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'],
                dayNamesShort: ['Sun', 'Mon', 'Tues', 'Wed', 'Thurs', 'Fri', 'Sat'],
                dayNamesMin: ['Sun', 'Mon', 'Tues', 'Wed', 'Thurs', 'Fri', 'Sat'],
                weekHeader: 'Sm',
                dateFormat: 'dd/mm/yy',
                firstDay: 0,
                isRTL: false,
                showMonthAfterYear: false,
                yearSuffix: ''
            };
            datepicker.setDefaults(datepicker.regional['SG']);

            return datepicker.regional['SG'];

        }));

        (function ($) {
            $.timepicker.regional['SG'] = {
                timeOnlyTitle: 'Escolha o horÃ¡rio',
                timeText: 'Time',
                hourText: 'Hour',
                minuteText: 'Minutes',
                secondText: 'Seconds',
                millisecText: 'Miliseconds',
                microsecText: 'Microsecends',
                timezoneText: 'Fuso horÃ¡rio',
                currentText: 'Current Timing',
                closeText: 'Confirm',
                timeFormat: 'HH:mm',
                amNames: ['a.m.', 'AM', 'A'],
                pmNames: ['p.m.', 'PM', 'P'],
                isRTL: false
            };
            $.timepicker.setDefaults($.timepicker.regional['SG']);
        })(jQuery);
        $('#selectDateTime').datetimepicker();
    </script>
</asp:Content>
