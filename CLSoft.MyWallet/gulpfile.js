/// <binding BeforeBuild='default' Clean='default' />
const gulp = require("gulp");
const concat = require("gulp-concat");

const vendorStyles = [
    "node_modules/bootstrap/dist/css/bootstrap.min.css",
    "Styles/custom-styles.css"
];
const vendorScripts = [
    "node_modules/jquery/dist/jquery.min.js",
    "node_modules/popper.js/dist/umd/popper.min.js",
    "node_modules/bootstrap/dist/js/bootstrap.min.js",
];

const validationScripts = [
    "node_modules/jquery-validation/dist/jquery.validate.min.js",
    "node_modules/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min.js",
    "Scripts/jquery.validate.unobtrusive.bootstrap.js",
];

gulp.task("default", ["build-vendor", "build-validation"]);

gulp.task("build-vendor", ["build-vendor-css", "build-vendor-js"]);

gulp.task("build-validation", ["build-validation-js"]);

gulp.task("build-vendor-css", () => {
    return gulp.src(vendorStyles)
        .pipe(concat("vendor.min.css"))
        .pipe(gulp.dest("wwwroot/css"));
});

gulp.task("build-vendor-js", () => {
    return gulp.src(vendorScripts)
        .pipe(concat("vendor.min.js"))
        .pipe(gulp.dest("wwwroot/js"));
});

gulp.task("build-validation-js", () => {
    return gulp.src(validationScripts)
        .pipe(concat("validation.min.js"))
        .pipe(gulp.dest("wwwroot/js"));
});