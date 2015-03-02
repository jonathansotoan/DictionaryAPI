using System.Web.Optimization;

namespace Dictionary.UI.App_Start
{
    public class BundleConfig
    {
        // from Scripts or Content folder for .js and .css files respectively
        const string LIB_PATH = "";
        const string HAND_CODED_FILES_PATH = "/app";

        public static void RegisterBundles(BundleCollection bundles)
        {
            // scripts
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts" + LIB_PATH + "/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts" + LIB_PATH + "/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts" + LIB_PATH + "/angular.js",
                "~/Scripts" + LIB_PATH + "/angular-sanitize.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/ckeditor").Include("~/Scripts" + LIB_PATH + "/ckeditor/ckeditor.js"));
            bundles.Add(new ScriptBundle("~/bundles/ie-compatibility-helpers").Include(
                "~/Scripts" + LIB_PATH + "/html5shiv.js",
                "~/Scripts" + LIB_PATH + "/respond.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts" + HAND_CODED_FILES_PATH + "/services/servicesModule.js",
                "~/Scripts" + HAND_CODED_FILES_PATH + "/services/printHttpErrorService.js",
                "~/Scripts" + HAND_CODED_FILES_PATH + "/services/apiUrlsService.js",
                "~/Scripts" + HAND_CODED_FILES_PATH + "/services/getSectionsService.js",
                "~/Scripts" + HAND_CODED_FILES_PATH + "/services/getWordsService.js",
                "~/Scripts" + HAND_CODED_FILES_PATH + "/services/saveWordService.js",
                "~/Scripts" + HAND_CODED_FILES_PATH + "/services/updateWordService.js",
                "~/Scripts" + HAND_CODED_FILES_PATH + "/services/deleteWordService.js",
                "~/Scripts" + HAND_CODED_FILES_PATH + "/directives/directivesModule.js",
                "~/Scripts" + HAND_CODED_FILES_PATH + "/directives/dctWordDirective.js",
                "~/Scripts" + HAND_CODED_FILES_PATH + "/controllers/controllersModule.js",
                "~/Scripts" + HAND_CODED_FILES_PATH + "/controllers/GlobalController.js",
                "~/Scripts" + HAND_CODED_FILES_PATH + "/controllers/WordsController.js",
                "~/Scripts" + HAND_CODED_FILES_PATH + "/app.js"
            ));

            // styles
            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
                "~/Content" + LIB_PATH + "/bootstrap.css",
                "~/Content" + LIB_PATH + "/starter-template.css"
            ));
            bundles.Add(new StyleBundle("~/bundles/listingWords").Include("~/Content" + HAND_CODED_FILES_PATH + "/listingWords.less"));
        }
    }
}
