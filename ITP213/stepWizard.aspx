﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="stepWizard.aspx.cs" Inherits="ITP213.stepWizard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="Content/jquery-steps.css">
    <style>
        body {
          font-size: 14px;
          font-family: Arial, Helvetica, sans-serif;
        }
        button, input, select, textarea {
          font-family: inherit;
          font-size: inherit;
          line-height: inherit;
        }
        /* jquery validation */
        label.error {
            color: #e7505a;
            margin-left: 10px;
            padding: 7px;
        }
        input.error {
            border: 2px solid #e7505a;
        }
    </style>
  <div id="demo">
    <div class="step-app">
      <ul class="step-steps">
        <li><a href="#tab1"><span class="number">1</span> Step 1</a></li>
        <li><a href="#tab2"><span class="number">2</span> Step 2</a></li>
        <li><a href="#tab3"><span class="number">3</span> Step 3</a></li>
        <li><a href="#tab4"><span class="number">4</span> Step 4</a></li>
        <li><a href="#tab5"><span class="number">5</span> Step 5</a></li>
      </ul>
      <div class="step-content">
        <div class="step-tab-panel" id="tab1">
          <h3>Tab1</h3>
          <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Minus facere porro iste quas numquam officia totam facilis suscipit, expedita rem quod, fugiat quo, veniam voluptate ut autem quia qui amet necessitatibus perferendis dignissimos ipsa doloremque. Necessitatibus delectus voluptatem unde. Architecto animi unde nostrum tenetur, doloremque distinctio, porro officiis dicta similique omnis quos odit ducimus minima ea quas facilis quod. Natus adipisci consequuntur sapiente alias culpa fugit tenetur, doloribus? Magni ipsum dolor debitis beatae quo, dicta voluptas veritatis, quos. Iusto quisquam doloribus laboriosam esse, dicta, odio facilis eligendi explicabo sequi accusamus a iste minus alias. Nisi sed laborum, aut maiores beatae aliquam voluptatum est enim impedit delectus blanditiis, neque sint nemo deleniti a quaerat voluptatem harum! Laboriosam assumenda, ullam iure. Corrupti maxime perferendis facilis ipsum, eius excepturi commodi consectetur, velit nobis reiciendis, ipsam! Maiores possimus tempore vel doloremque in facilis qui quos molestias. Culpa eius magnam repellat, ad eaque. Possimus, voluptatem.</p>
        </div>
        <div class="step-tab-panel" id="tab2">
          <h3>Tab2</h3>
          <form name="frmInfo" id="frmInfo">
            First name:<br>
            <input type="text" name="txtFirstName" required>
            <br> Last name:<br>
            <input type="text" name="txtLastName" required>
          </form>
        </div>
        <div class="step-tab-panel" id="tab3">
          <h3>Tab3</h3>
          <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Magni dicta nulla veritatis totam vel blanditiis, cumque minima harum reiciendis officia, accusamus ipsum esse nam itaque consequuntur eum! Nesciunt maiores dignissimos repellendus cumque, ea nemo perspiciatis dolor accusantium, enim modi veniam deleniti omnis unde, ad temporibus quasi incidunt placeat magni qui totam porro nobis alias culpa. Sit nisi dolorum illum! Voluptatum magnam dolorem minima impedit perspiciatis obcaecati odit iusto maxime dolorum, ut consequuntur cum quia minus alias sunt libero corrupti quam quidem placeat enim, aperiam, facere! Quae sit incidunt blanditiis quisquam cum a illo, dolore ex expedita fugit aliquam, id temporibus illum excepturi omnis autem sequi. Aspernatur eos numquam in laboriosam debitis sapiente consequuntur facere, esse iste delectus, impedit aliquid error! At dignissimos molestias accusantium sequi perferendis quidem quas quia nobis expedita? Reiciendis minima quaerat adipisci architecto, dignissimos ut, dicta nesciunt, quae a maxime aliquam consequuntur aspernatur doloribus eveniet, quasi reprehenderit!</p>
        </div>
        <div class="step-tab-panel" id="tab4">
          <h3>Tab4</h3>
          <form name="frmLogin" id="frmLogin">
            Email address:<br>
            <input type="text" name="txtEmail" required>
            <br> Password:<br>
            <input type="text" name="txtPassword" required>
          </form>
        </div>
        <div class="step-tab-panel" id="tab5">
          <h3>Tab5</h3>
          <form name="frmMobile" id="frmMobile">
            Mobile No:<br>
            <input type="text" name="txtMobileNum" required>
          </form>
        </div>
      </div>
      <div class="step-footer">
        <button data-direction="prev" class="step-btn">Previous</button>
        <button data-direction="next" class="step-btn">Next</button>
        <button data-direction="finish" class="step-btn">Finish</button>
      </div>
    </div>
  </div>

  <script src="http://code.jquery.com/jquery-latest.min.js"></script>
  <script src="https://cdn.jsdelivr.net/npm/jquery-validation@1.19.0/dist/jquery.validate.min.js"></script>
  <script src="Scripts/jquery-steps.js"></script>
  <script>
    var frmInfo = $('#frmInfo');
    var frmInfoValidator = frmInfo.validate();

    var frmLogin = $('#frmLogin');
    var frmLoginValidator = frmLogin.validate();

    var frmMobile = $('#frmMobile');
    var frmMobileValidator = frmMobile.validate();

    $('#demo').steps({
      onChange: function (currentIndex, newIndex, stepDirection) {
        console.log('onChange', currentIndex, newIndex, stepDirection);
        // tab1
        if (currentIndex === 3) {
          if (stepDirection === 'forward') {
            var valid = frmLogin.valid();
            return valid;
          }
          if (stepDirection === 'backward') {
            frmLoginValidator.resetForm();
          }
        }

        // tab2
        if (currentIndex === 1) {
          if (stepDirection === 'forward') {
            var valid = frmInfo.valid();
            return valid;
          }
          if (stepDirection === 'backward') {
            frmInfoValidator.resetForm();
          }
        }

       

        return true;

      },
      onFinish: function () {
        alert('Wizard Completed');
      }
    });
  </script>
</asp:Content>
