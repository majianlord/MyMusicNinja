<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title -My Music Ninja</title>
    @Styles.Render("~/Content/css")
    @Styles.Render("~/Content/jqueryui")
    @Scripts.Render("~/bundles/modernizr")

</head>
<body>
    <div class="header">
        <div class="container">
            <div class="logo col-lg-3 col-md-3 col-sm-3">
                <a href="@Url.Action("Index", "Home")"><img src="~/Content/images/logo.png" alt="logo"></a>
            </div>
            <div class="navigation col-lg-6 col-md-6 col-sm-6">
                <nav role="navigation" class="navbar navbar-default togl">
                    <div class="navbar-header">
                        <button type="button" data-target="#navbarCollapse" data-toggle="collapse" class="navbar-toggle">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                    </div>
                    <div id="navbarCollapse" class="collapse navbar-collapse">
                        <ul class="nav navbar-nav">
                            <li><a href="@Url.Action("Index", "Home")">Home</a></li>
                            <li><a href="@Url.Action("About", "Home")">About us</a></li>
                            <li><a href="@Url.Action("Tools", "Home")">Tools</a></li>
                            <!--<li><a href="library.html"> Library</a></li> -->
                            <li><a href="@Url.Action("Contact", "Home")">Contact Us</a></li>
                        </ul>

                    </div>
                </nav>
            </div>
            <div class="sig-up col-lg-3 col-md-3 col-sm-3">
                <ul class="sg">
                    <li class="ups"><a href="#">Signup</a></li>
                    <li class="ins"><a href="#">Login</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="container body-content">
        @RenderBody()
        <hr />
    </div>

    <div class="container">
        <footer>
            <div class="se-v col-lg-4 col-md-4 col-sm-4">
                <!--
    <h2 class="ftr-b">information</h2>
    <ul>
        <li><a href="#">Home</a></li>
        <li><a href="#" target="_blank">Lorem ipsum dolor</a></li>
        <li><a href="#">Lorem ipsum dolor</a></li>
        <li><a href="#">Lorem ipsum dolor</a></li>
        <li><a href="#">Lorem ipsum dolor</a></li>
    </ul>
        -->
            </div>

            <div class="se-v1 col-lg-4 col-md-4 col-sm-4">
                <h2 class="ftr-b">Testimonials</h2>
                <p>
                    "With all our Music Online the students no longer bug me for a missing piece or cant say they left it at school as to why they didnt practice"
                    <br><span class="cus">(Del City HighSchool)</span>
                    <!--<a class="ftr-test" href="#">View More</a>-->
                </p>
            </div>

            <div class="se-v2 col-lg-4 col-md-4 col-sm-4">
                <div class="vb">
                    <a class="nin" href="#">MyMusicNinja.com</a>
                    <ul class="vnm">
                        <li>E-mail :<a href="#"> Support@mymusicninja.com</a></li>
                    </ul>

                    <ul class="social">

                        <li>Follow us on:</li>
                        <li><a href="#"><img src="~/content/images/fb--icon.png" alt=""></a></li>
                        <li><a href="#"><img src="~/content/images/twt.png" alt=""></a></li>
                    </ul>

                </div>

            </div>


        </footer>
    </div>
    <div class="copy-right">
        <div class=" container">

            <p>
                Copyright © 2018 My Music Ninja. All Rights Reserved.
            </p>

        </div>
    </div>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/jqueryui")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("Scripts", required:=False)
</body>
</html>
