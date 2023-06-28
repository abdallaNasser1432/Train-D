﻿namespace Train_D.Templates
{
    public static class HtmlContent
    {
        #region verification_success
        public const string verification_success = "<html>\r\n\r\n<head>\r\n  <link href=\"https://fonts.googleapis.com/css?family=Nunito+Sans:400,400i,700,900&display=swap\" rel=\"stylesheet\">\r\n</head>\r\n<style>\r\n  body {\r\n    text-align: center;\r\n    padding: 40px 0;\r\n    background: #EBF0F5;\r\n  }\r\n\r\n  h1 {\r\n    color: #88B04B;\r\n    font-family: \"Nunito Sans\", \"Helvetica Neue\", sans-serif;\r\n    font-weight: 900;\r\n    font-size: 40px;\r\n    margin-bottom: 10px;\r\n  }\r\n\r\n  p {\r\n    color: #404F5E;\r\n    font-family: \"Nunito Sans\", \"Helvetica Neue\", sans-serif;\r\n    font-size: 20px;\r\n    margin: 0;\r\n  }\r\n\r\n  i {\r\n    color: #9ABC66;\r\n    font-size: 100px;\r\n    line-height: 200px;\r\n    margin-left: -15px;\r\n  }\r\n\r\n  .card {\r\n    background: white;\r\n    padding: 60px;\r\n    border-radius: 4px;\r\n    box-shadow: 0 2px 3px #C8D0D8;\r\n    display: inline-block;\r\n    margin: 0 auto;\r\n  }\r\n</style>\r\n\r\n<body>\r\n  <div class=\"card\">\r\n    <div style=\"border-radius:200px; height:200px; width:200px; background: #F8FAF5; margin:0 auto;\">\r\n      <i class=\"checkmark\">✓</i>\r\n    </div>\r\n    <h1>Success</h1>\r\n    <p>Congratulations,<br> your account has been successfully created!</p>\r\n  </div>\r\n</body>\r\n\r\n</html>";
        #endregion
        #region ResetPasswordForm
        public const string ResetPasswordForm = "<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <title>change password form</title>\r\n    <style>\r\n        .mainDiv {\r\n            display: flex;\r\n            min-height: 100%;\r\n            align-items: center;\r\n            justify-content: center;\r\n            background-color: #f9f9f9;\r\n            font-family: 'Open Sans', sans-serif;\r\n        }\r\n\r\n        .cardStyle {\r\n            width: 500px;\r\n            border-color: white;\r\n            background: #fff;\r\n            padding: 36px 0;\r\n            border-radius: 4px;\r\n            margin: 30px 0;\r\n            box-shadow: 0px 0 2px 0 rgba(0,0,0,0.25);\r\n        }\r\n\r\n        #signupLogo {\r\n            max-height: 230px;\r\n            margin: auto;\r\n            display: flex;\r\n            flex-direction: column;\r\n        }\r\n\r\n        .formTitle {\r\n            font-weight: 600;\r\n            margin-top: 20px;\r\n            color: #2F2D3B;\r\n            text-align: center;\r\n        }\r\n\r\n        .inputLabel {\r\n            font-size: 12px;\r\n            color: #555;\r\n            margin-bottom: 6px;\r\n            margin-top: 24px;\r\n        }\r\n\r\n        .inputDiv {\r\n            width: 70%;\r\n            display: flex;\r\n            flex-direction: column;\r\n            margin: auto;\r\n        }\r\n\r\n        input {\r\n            height: 40px;\r\n            font-size: 16px;\r\n            border-radius: 4px;\r\n            border: none;\r\n            border: solid 1px #ccc;\r\n            padding: 0 11px;\r\n        }\r\n\r\n            input:disabled {\r\n                cursor: not-allowed;\r\n                border: solid 1px #eee;\r\n            }\r\n\r\n        .buttonWrapper {\r\n            margin-top: 40px;\r\n        }\r\n\r\n        .submitButton {\r\n            width: 70%;\r\n            height: 40px;\r\n            margin: auto;\r\n            display: block;\r\n            color: #fff;\r\n            background-color: #065492;\r\n            border-color: #065492;\r\n            text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.12);\r\n            box-shadow: 0 2px 0 rgba(0, 0, 0, 0.035);\r\n            border-radius: 4px;\r\n            font-size: 14px;\r\n            cursor: pointer;\r\n        }\r\n\r\n            .submitButton:disabled,\r\n            button[disabled] {\r\n                border: 1px solid #cccccc;\r\n                background-color: #cccccc;\r\n                color: #666666;\r\n            }\r\n\r\n        #loader {\r\n            position: absolute;\r\n            z-index: 1;\r\n            margin: -2px 0 0 10px;\r\n            border: 4px solid #f3f3f3;\r\n            border-radius: 50%;\r\n            border-top: 4px solid #666666;\r\n            width: 14px;\r\n            height: 14px;\r\n            -webkit-animation: spin 2s linear infinite;\r\n            animation: spin 2s linear infinite;\r\n        }\r\n\r\n        @keyframes spin {\r\n            0% {\r\n                transform: rotate(0deg);\r\n            }\r\n\r\n            100% {\r\n                transform: rotate(360deg);\r\n            }\r\n        }\r\n    </style>\r\n\r\n</head>\r\n<body>\r\n    <!-- partial:index.partial.html -->\r\n    <div id=\"my-element\" class=\"mainDiv\">\r\n        <div class=\"cardStyle\">\r\n            <form action=\"\" method=\"post\" name=\"signupForm\" id=\"signupForm\">\r\n\r\n                <img src=\"\" id=\"signupLogo\" />\r\n\r\n                <h2 class=\"formTitle\">\r\n                    Reset your Password\r\n                </h2>\r\n\r\n                <div class=\"inputDiv\">\r\n                    <label class=\"inputLabel\" for=\"password\">New Password</label>\r\n                    <input type=\"password\" id=\"password\" name=\"password\" required>\r\n                </div>\r\n\r\n                <div class=\"inputDiv\">\r\n                    <label class=\"inputLabel\" for=\"confirmPassword\">Confirm Password</label>\r\n                    <input type=\"password\" id=\"confirmPassword\" name=\"confirmPassword\">\r\n                </div>\r\n\r\n                <div class=\"buttonWrapper\">\r\n                    <button type=\"submit\" id=\"submitButton\" onclick=\"validateSignupForm()\" class=\"submitButton pure-button pure-button-primary\">\r\n                        <span>Submit</span>\r\n                        <span id=\"loader\"></span>\r\n                    </button>\r\n                </div>\r\n\r\n            </form>\r\n        </div>\r\n    </div>\r\n    <!-- partial -->\r\n    <script>\r\n        var password = document.getElementById(\"password\")\r\n            , confirm_password = document.getElementById(\"confirmPassword\");\r\n\r\n        // Get the current URL\r\n        const url = new URL(window.location.href);\r\n\r\n        const url_ = window.location.href.split('?')[0];\r\n    \r\n        // Get the value of the 'token' query parameter\r\n        const token = url.searchParams.get('token');\r\n\r\n        // Get the value of the 'email' query parameter\r\n        const email = url.searchParams.get('email');\r\n        // Get a reference to an existing HTML element\r\n        const element = document.getElementById('my-element');\r\n\r\n        let myDoc = new DOMParser();\r\n\r\n        document.getElementById('signupLogo').src = \"https://img.freepik.com/free-vector/steam-train-design_1152-67.jpg?w=740&t=st=1687725147~exp=1687725747~hmac=ced1ad19588ab0c708699a573a8eb726257ea1578cad73e3672d0bd0bce66d71\";\r\n        enableSubmitButton();\r\n\r\n        function validatePassword() {\r\n            const regex = /^(?=.*[A-Z])(?=.*\\d)(?=.*[!@#$%^&*()_+\\-=\\[\\]{};':\"\\\\|,.<>\\/?])(?=.*[a-z]).{8,}$/;\r\n            if (!regex.test(password.value)) {\r\n                password.setCustomValidity('Password must be at least 8 characters long and contain at least one uppercase letter, one special character, and one number');\r\n                return false;\r\n            }\r\n            else if (password.value != confirm_password.value) {\r\n                password.setCustomValidity('');\r\n                confirm_password.setCustomValidity(\"Passwords Don't Match\");\r\n                return false;\r\n            } else {\r\n                password.setCustomValidity('');\r\n                confirm_password.setCustomValidity('');\r\n                return true;\r\n            }\r\n        }\r\n\r\n        password.onchange = validatePassword;\r\n        confirm_password.onkeyup = validatePassword;\r\n\r\n        function enableSubmitButton() {\r\n            document.getElementById('submitButton').disabled = false;\r\n            document.getElementById('loader').style.display = 'none';\r\n        }\r\n\r\n        function disableSubmitButton() {\r\n            document.getElementById('submitButton').disabled = true;\r\n            document.getElementById('loader').style.display = 'unset';\r\n        }\r\n\r\n        function validateSignupForm() {\r\n            \r\n            var form = document.getElementById('signupForm');\r\n\r\n            for (var i = 0; i < form.elements.length; i++) {\r\n                if (form.elements[i].value === '' && form.elements[i].hasAttribute('required')) {\r\n                    console.log('There are some required fields!');\r\n                    return false;\r\n                }\r\n            }\r\n\r\n            if (!validatePassword()) {\r\n                return false;\r\n            }\r\n            \r\n            fetch(url_, {\r\n                method: \"POST\",\r\n                body: JSON.stringify({\r\n                    Password: password.value,\r\n                    Email: email,\r\n                    Token: token\r\n                }),\r\n                headers: {\r\n                    \"Content-type\": \"application/json; charset=UTF-8\"\r\n                }\r\n            })\r\n                .then((response) => response.text())\r\n                .then((json) => document.write(json));\r\n        }\r\n\r\n    </script>\r\n\r\n</body>\r\n</html>\r\n";
        #endregion
        #region ResetEmailTemplate
        public const string ResetEmailTemplate = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n  <head>\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n    <meta name=\"x-apple-disable-message-reformatting\" />\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\r\n    <meta name=\"color-scheme\" content=\"light dark\" />\r\n    <meta name=\"supported-color-schemes\" content=\"light dark\" />\r\n    <title></title>\r\n    <style type=\"text/css\" rel=\"stylesheet\" media=\"all\">\r\n    /* Base ------------------------------ */\r\n    \r\n    @import url(\"https://fonts.googleapis.com/css?family=Nunito+Sans:400,700&display=swap\");\r\n    body {\r\n      width: 100% !important;\r\n      height: 100%;\r\n      margin: 0;\r\n      -webkit-text-size-adjust: none;\r\n    }\r\n    \r\n    a {\r\n      color: #3869D4;\r\n    }\r\n    \r\n    a img {\r\n      border: none;\r\n    }\r\n    \r\n    td {\r\n      word-break: break-word;\r\n    }\r\n    \r\n    .preheader {\r\n      display: none !important;\r\n      visibility: hidden;\r\n      mso-hide: all;\r\n      font-size: 1px;\r\n      line-height: 1px;\r\n      max-height: 0;\r\n      max-width: 0;\r\n      opacity: 0;\r\n      overflow: hidden;\r\n    }\r\n    /* Type ------------------------------ */\r\n    \r\n    body,\r\n    td,\r\n    th {\r\n      font-family: \"Nunito Sans\", Helvetica, Arial, sans-serif;\r\n    }\r\n    \r\n    h1 {\r\n      margin-top: 0;\r\n      color: #333333;\r\n      font-size: 22px;\r\n      font-weight: bold;\r\n      text-align: left;\r\n    }\r\n    \r\n    h2 {\r\n      margin-top: 0;\r\n      color: #333333;\r\n      font-size: 16px;\r\n      font-weight: bold;\r\n      text-align: left;\r\n    }\r\n    \r\n    h3 {\r\n      margin-top: 0;\r\n      color: #333333;\r\n      font-size: 14px;\r\n      font-weight: bold;\r\n      text-align: left;\r\n    }\r\n    \r\n    td,\r\n    th {\r\n      font-size: 16px;\r\n    }\r\n    \r\n    p,\r\n    ul,\r\n    ol,\r\n    blockquote {\r\n      margin: .4em 0 1.1875em;\r\n      font-size: 16px;\r\n      line-height: 1.625;\r\n    }\r\n    \r\n    p.sub {\r\n      font-size: 13px;\r\n    }\r\n    /* Utilities ------------------------------ */\r\n    \r\n    .align-right {\r\n      text-align: right;\r\n    }\r\n    \r\n    .align-left {\r\n      text-align: left;\r\n    }\r\n    \r\n    .align-center {\r\n      text-align: center;\r\n    }\r\n    \r\n    .u-margin-bottom-none {\r\n      margin-bottom: 0;\r\n    }\r\n    /* Buttons ------------------------------ */\r\n    \r\n    .button {\r\n      background-color: #3869D4;\r\n      border-top: 10px solid #3869D4;\r\n      border-right: 18px solid #3869D4;\r\n      border-bottom: 10px solid #3869D4;\r\n      border-left: 18px solid #3869D4;\r\n      display: inline-block;\r\n      color: #FFF;\r\n      text-decoration: none;\r\n      border-radius: 3px;\r\n      box-shadow: 0 2px 3px rgba(0, 0, 0, 0.16);\r\n      -webkit-text-size-adjust: none;\r\n      box-sizing: border-box;\r\n    }\r\n    \r\n    .button--green {\r\n      background-color: #22BC66;\r\n      border-top: 10px solid #22BC66;\r\n      border-right: 18px solid #22BC66;\r\n      border-bottom: 10px solid #22BC66;\r\n      border-left: 18px solid #22BC66;\r\n    }\r\n    \r\n    .button--red {\r\n      background-color: #FF6136;\r\n      border-top: 10px solid #FF6136;\r\n      border-right: 18px solid #FF6136;\r\n      border-bottom: 10px solid #FF6136;\r\n      border-left: 18px solid #FF6136;\r\n    }\r\n    \r\n    @media only screen and (max-width: 500px) {\r\n      .button {\r\n        width: 100% !important;\r\n        text-align: center !important;\r\n      }\r\n    }\r\n    /* Attribute list ------------------------------ */\r\n    \r\n    .attributes {\r\n      margin: 0 0 21px;\r\n    }\r\n    \r\n    .attributes_content {\r\n      background-color: #F4F4F7;\r\n      padding: 16px;\r\n    }\r\n    \r\n    .attributes_item {\r\n      padding: 0;\r\n    }\r\n    /* Related Items ------------------------------ */\r\n    \r\n    .related {\r\n      width: 100%;\r\n      margin: 0;\r\n      padding: 25px 0 0 0;\r\n      -premailer-width: 100%;\r\n      -premailer-cellpadding: 0;\r\n      -premailer-cellspacing: 0;\r\n    }\r\n    \r\n    .related_item {\r\n      padding: 10px 0;\r\n      color: #CBCCCF;\r\n      font-size: 15px;\r\n      line-height: 18px;\r\n    }\r\n    \r\n    .related_item-title {\r\n      display: block;\r\n      margin: .5em 0 0;\r\n    }\r\n    \r\n    .related_item-thumb {\r\n      display: block;\r\n      padding-bottom: 10px;\r\n    }\r\n    \r\n    .related_heading {\r\n      border-top: 1px solid #CBCCCF;\r\n      text-align: center;\r\n      padding: 25px 0 10px;\r\n    }\r\n    /* Discount Code ------------------------------ */\r\n    \r\n    .discount {\r\n      width: 100%;\r\n      margin: 0;\r\n      padding: 24px;\r\n      -premailer-width: 100%;\r\n      -premailer-cellpadding: 0;\r\n      -premailer-cellspacing: 0;\r\n      background-color: #F4F4F7;\r\n      border: 2px dashed #CBCCCF;\r\n    }\r\n    \r\n    .discount_heading {\r\n      text-align: center;\r\n    }\r\n    \r\n    .discount_body {\r\n      text-align: center;\r\n      font-size: 15px;\r\n    }\r\n    /* Social Icons ------------------------------ */\r\n    \r\n    .social {\r\n      width: auto;\r\n    }\r\n    \r\n    .social td {\r\n      padding: 0;\r\n      width: auto;\r\n    }\r\n    \r\n    .social_icon {\r\n      height: 20px;\r\n      margin: 0 8px 10px 8px;\r\n      padding: 0;\r\n    }\r\n    /* Data table ------------------------------ */\r\n    \r\n    .purchase {\r\n      width: 100%;\r\n      margin: 0;\r\n      padding: 35px 0;\r\n      -premailer-width: 100%;\r\n      -premailer-cellpadding: 0;\r\n      -premailer-cellspacing: 0;\r\n    }\r\n    \r\n    .purchase_content {\r\n      width: 100%;\r\n      margin: 0;\r\n      padding: 25px 0 0 0;\r\n      -premailer-width: 100%;\r\n      -premailer-cellpadding: 0;\r\n      -premailer-cellspacing: 0;\r\n    }\r\n    \r\n    .purchase_item {\r\n      padding: 10px 0;\r\n      color: #51545E;\r\n      font-size: 15px;\r\n      line-height: 18px;\r\n    }\r\n    \r\n    .purchase_heading {\r\n      padding-bottom: 8px;\r\n      border-bottom: 1px solid #EAEAEC;\r\n    }\r\n    \r\n    .purchase_heading p {\r\n      margin: 0;\r\n      color: #85878E;\r\n      font-size: 12px;\r\n    }\r\n    \r\n    .purchase_footer {\r\n      padding-top: 15px;\r\n      border-top: 1px solid #EAEAEC;\r\n    }\r\n    \r\n    .purchase_total {\r\n      margin: 0;\r\n      text-align: right;\r\n      font-weight: bold;\r\n      color: #333333;\r\n    }\r\n    \r\n    .purchase_total--label {\r\n      padding: 0 15px 0 0;\r\n    }\r\n    \r\n    body {\r\n      background-color: #F2F4F6;\r\n      color: #51545E;\r\n    }\r\n    \r\n    p {\r\n      color: #51545E;\r\n    }\r\n    \r\n    .email-wrapper {\r\n      width: 100%;\r\n      margin: 0;\r\n      padding: 0;\r\n      -premailer-width: 100%;\r\n      -premailer-cellpadding: 0;\r\n      -premailer-cellspacing: 0;\r\n      background-color: #F2F4F6;\r\n    }\r\n    \r\n    .email-content {\r\n      width: 100%;\r\n      margin: 0;\r\n      padding: 0;\r\n      -premailer-width: 100%;\r\n      -premailer-cellpadding: 0;\r\n      -premailer-cellspacing: 0;\r\n    }\r\n    /* Masthead ----------------------- */\r\n    \r\n    .email-masthead {\r\n      padding: 25px 0;\r\n      text-align: center;\r\n    }\r\n    \r\n    .email-masthead_logo {\r\n      width: 94px;\r\n    }\r\n    \r\n    .email-masthead_name {\r\n      font-size: 16px;\r\n      font-weight: bold;\r\n      color: #A8AAAF;\r\n      text-decoration: none;\r\n      text-shadow: 0 1px 0 white;\r\n    }\r\n    /* Body ------------------------------ */\r\n    \r\n    .email-body {\r\n      width: 100%;\r\n      margin: 0;\r\n      padding: 0;\r\n      -premailer-width: 100%;\r\n      -premailer-cellpadding: 0;\r\n      -premailer-cellspacing: 0;\r\n    }\r\n    \r\n    .email-body_inner {\r\n      width: 570px;\r\n      margin: 0 auto;\r\n      padding: 0;\r\n      -premailer-width: 570px;\r\n      -premailer-cellpadding: 0;\r\n      -premailer-cellspacing: 0;\r\n      background-color: #FFFFFF;\r\n    }\r\n    \r\n    .email-footer {\r\n      width: 570px;\r\n      margin: 0 auto;\r\n      padding: 0;\r\n      -premailer-width: 570px;\r\n      -premailer-cellpadding: 0;\r\n      -premailer-cellspacing: 0;\r\n      text-align: center;\r\n    }\r\n    \r\n    .email-footer p {\r\n      color: #A8AAAF;\r\n    }\r\n    \r\n    .body-action {\r\n      width: 100%;\r\n      margin: 30px auto;\r\n      padding: 0;\r\n      -premailer-width: 100%;\r\n      -premailer-cellpadding: 0;\r\n      -premailer-cellspacing: 0;\r\n      text-align: center;\r\n    }\r\n    \r\n    .body-sub {\r\n      margin-top: 25px;\r\n      padding-top: 25px;\r\n      border-top: 1px solid #EAEAEC;\r\n    }\r\n    \r\n    .content-cell {\r\n      padding: 45px;\r\n    }\r\n    /*Media Queries ------------------------------ */\r\n    \r\n    @media only screen and (max-width: 600px) {\r\n      .email-body_inner,\r\n      .email-footer {\r\n        width: 100% !important;\r\n      }\r\n    }\r\n    \r\n    @media (prefers-color-scheme: dark) {\r\n      body,\r\n      .email-body,\r\n      .email-body_inner,\r\n      .email-content,\r\n      .email-wrapper,\r\n      .email-masthead,\r\n      .email-footer {\r\n        background-color: #333333 !important;\r\n        color: #FFF !important;\r\n      }\r\n      p,\r\n      ul,\r\n      ol,\r\n      blockquote,\r\n      h1,\r\n      h2,\r\n      h3,\r\n      span,\r\n      .purchase_item {\r\n        color: #FFF !important;\r\n      }\r\n      .attributes_content,\r\n      .discount {\r\n        background-color: #222 !important;\r\n      }\r\n      .email-masthead_name {\r\n        text-shadow: none !important;\r\n      }\r\n    }\r\n    \r\n    :root {\r\n      color-scheme: light dark;\r\n      supported-color-schemes: light dark;\r\n    }\r\n    </style>\r\n  </head>\r\n  <body>\r\n    <span class=\"preheader\">Use this link to reset your password. The link is only valid for 24 hours.</span>\r\n    <table class=\"email-wrapper\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\">\r\n      <tr>\r\n        <td align=\"center\">\r\n          <table class=\"email-content\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\">\r\n            <tr>\r\n              <td class=\"email-masthead\">\r\n                <a href=\"https://example.com\" class=\"f-fallback email-masthead_name\">\r\n                Train-D\r\n              </a>\r\n              </td>\r\n            </tr>\r\n            <!-- Email Body -->\r\n            <tr>\r\n              <td class=\"email-body\" width=\"570\" cellpadding=\"0\" cellspacing=\"0\">\r\n                <table class=\"email-body_inner\" align=\"center\" width=\"570\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\">\r\n                  <!-- Body content -->\r\n                  <tr>\r\n                    <td class=\"content-cell\">\r\n                      <div class=\"f-fallback\">\r\n                        <h1>Hi {{name}},</h1>\r\n                        <p>You recently requested to reset your password for your Train-D account. Use the button below to reset it. <strong>This password reset is only valid for the next 24 hours.</strong></p>\r\n                        <!-- Action -->\r\n                        <table class=\"body-action\" align=\"center\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\">\r\n                          <tr>\r\n                            <td align=\"center\">\r\n                              <!-- Border based button\r\n           https://litmus.com/blog/a-guide-to-bulletproof-buttons-in-email-design -->\r\n                              <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" role=\"presentation\">\r\n                                <tr>\r\n                                  <td align=\"center\">\r\n                                    <a href=\"{{action_url}}\" class=\"f-fallback button button--green\" target=\"_blank\">Reset your password</a>\r\n                                  </td>\r\n                                </tr>\r\n                              </table>\r\n                            </td>\r\n                          </tr>\r\n                        </table>\r\n                        <p>For security, this request was received from a Android device using Microsof Edge. If you did not request a password reset, please ignore this email or <a href=\"{{support_url}}\">contact support</a> if you have questions.</p>\r\n                        <p>Thanks,\r\n                          <br>The Train-D team</p>\r\n                        <!-- Sub copy -->\r\n                        <table class=\"body-sub\" role=\"presentation\">\r\n                          <tr>\r\n                            <td>\r\n                              <p class=\"f-fallback sub\">If you’re having trouble with the button above, copy and paste the URL below into your web browser.</p>\r\n                              <p class=\"f-fallback sub\">{{action_url}}</p>\r\n                            </td>\r\n                          </tr>\r\n                        </table>\r\n                      </div>\r\n                    </td>\r\n                  </tr>\r\n                </table>\r\n              </td>\r\n            </tr>\r\n            <tr>\r\n              <td>\r\n                <table class=\"email-footer\" align=\"center\" width=\"570\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\">\r\n                  <tr>\r\n                    <td class=\"content-cell\" align=\"center\">\r\n                        <p class=\"f-fallback sub align-center\">\r\n                            [Train-D, LLC]\r\n                            <br />1234 Street Rd.\r\n                            <br />Ismailia-Egypt\r\n                        </p>\r\n                    </td>\r\n                  </tr>\r\n                </table>\r\n              </td>\r\n            </tr>\r\n          </table>\r\n        </td>\r\n      </tr>\r\n    </table>\r\n  </body>\r\n</html>";
        #endregion
        #region EmailTemplate
        public const string EmailTemplate = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <meta http-equiv=\"Content-type\" content=\"text/html; charset=utf-8\" />\r\n    <meta name=\"viewport\"\r\n          content=\"width=device-width, initial-scale=1, maximum-scale=1\" />\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\" />\r\n    <meta name=\"format-detection\" content=\"date=no\" />\r\n    <meta name=\"format-detection\" content=\"address=no\" />\r\n    <meta name=\"format-detection\" content=\"telephone=no\" />\r\n    <meta name=\"x-apple-disable-message-reformatting\" />\r\n    <link href=\"https://fonts.googleapis.com/css?family=Muli:400,400i,700,700i\"\r\n          rel=\"stylesheet\" />\r\n    <title>Welcome</title>\r\n    <style type=\"text/css\" media=\"screen\">\r\n        /* Linked Styles */\r\n        body {\r\n            background: #eee;\r\n            padding: 0 !important;\r\n            margin: 0 !important;\r\n            display: block !important;\r\n            min-width: 100% !important;\r\n            width: 100% !important;\r\n            -webkit-text-size-adjust: none;\r\n        }\r\n\r\n        .email--background {\r\n            background: #eee;\r\n            padding: 10px;\r\n            text-align: center;\r\n        }\r\n\r\n        .email--inner-container {\r\n            padding: 0 5% 40px;\r\n        }\r\n\r\n        img {\r\n            max-width: 100%;\r\n            display: block;\r\n            -ms-interpolation-mode: bicubic; /* Allow smoother rendering of resized image in Internet Explorer */\r\n        }\r\n\r\n        p {\r\n            font-family: 'Muli';\r\n            font-size: 16px;\r\n            line-height: 1.5;\r\n            color: #000000;\r\n            padding: 10px !important;\r\n            margin: 0 !important;\r\n        }\r\n\r\n        .email--container, .pre-header {\r\n            max-width: 500px;\r\n            background: #fff;\r\n            margin: 0 auto;\r\n            overflow: hidden;\r\n            border-radius: 5px;\r\n        }\r\n\r\n        .pre-header {\r\n            background: #eee;\r\n            color: #eee;\r\n            font-size: 5px;\r\n        }\r\n\r\n        .cta {\r\n            font-family: 'Muli';\r\n            display: inline-block;\r\n            padding: 10px 20px;\r\n            color: #000;\r\n            background: #FF9800;\r\n            text-decoration: none;\r\n            letter-spacing: 2px;\r\n            text-transform: uppercase;\r\n            border-radius: 5px;\r\n            font-size: 13px;\r\n        }\r\n\r\n        .footer-junk {\r\n            padding: 20px;\r\n            font-size: 10px;\r\n        }\r\n\r\n            .footer-junk a {\r\n                color: #bbb;\r\n            }\r\n \r\n    </style>\r\n</head>\r\n<body class=\"body\">\r\n    <div class=\"email--background\">\r\n        <div class=\"email--container\">\r\n            <img src=\"https://img.freepik.com/free-vector/train-logo_23-2147510654.jpg?w=740&t=st=1687588616~exp=1687589216~hmac=8fb3723cafd3d78bf12bf3ed4c2fdc59941c8b399451cffc1e727db16d0e9493\" alt=\"Train-D\">\r\n\r\n            <div class=\"email--inner-container\">\r\n                <h1>Welcome, [username]</h1>\r\n                <h1>Thanks for joining Train-D!</h1>\r\n                <p>To finish signing up, please confirm your email address.<br /> This ensures we have the right email in case we need to contact you.</p>\r\n                <a href=\"https://www.youtube.com\" class=\"cta\" style=\"text-decoration:none; color:snow;\">Confirm Your Email</a>\r\n            </div>\r\n\r\n        </div>\r\n\r\n        <div class=\"footer-junk\">\r\n            <a href=\"#\">Unsubscribe</a>\r\n        </div>\r\n\r\n    </div>\r\n</body>\r\n</html>";
        #endregion
    }
}
