CKEDITOR.editorConfig = function( config ) {
    config.uiColor = '#41708f';
    config.language = 'es';
    config.removeButtons = 'About';

    // does not work :(
    config.blockedKeystrokes = [
        13 //enter
    ];
};
