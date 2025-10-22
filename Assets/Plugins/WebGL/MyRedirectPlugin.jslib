    mergeInto(LibraryManager.library, {
        RedirectToURL: function (url) {
            window.location.href = UTF8ToString(url);
        },
    });