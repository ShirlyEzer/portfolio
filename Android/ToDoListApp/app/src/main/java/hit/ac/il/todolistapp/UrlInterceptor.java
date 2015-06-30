package hit.ac.il.todolistapp;

import android.webkit.WebView;
import android.webkit.WebViewClient;

/**
 * A class that is in charge to keep all the links in same web view, extends WebViewClient.
 */
public class UrlInterceptor extends WebViewClient {

    @Override
    public boolean shouldOverrideUrlLoading(WebView view, String url) {
        view.loadUrl(url);
        return true;
    }
}
