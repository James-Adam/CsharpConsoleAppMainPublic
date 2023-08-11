var gulp = require('gulp'),
    htmlclean = require('gulp-htmlclean'),
    uglify = require('gulp-uglify');

//folders

var folders = {
    root: "./wwwwroot/CsharpConsoleAppMainSolution/NetFramework/New folder/StateConfigurationSolution/StateConfiguration"
};


gulp.task('html', function () {
    var out = folders.root + 'html/';
    return gulp.src(folders.root + 'html_develop/**/*')

        .pipe(htmlclean())
        .pipe(gulp.dest(out))
});


gulp.task('js', ['html'], function()
{
    return gulp.src(folders.root + 'js_develop/**/*')

        .pipe(uglify())
        .pipe(gulp.dest(folders.root + 'js/'))
});

gulp.task('default', ['js']);