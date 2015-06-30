package company.com.bmiform;

import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.webkit.WebView;
import android.widget.TextView;


public class MainActivity extends ActionBarActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        /*String stringHtml = getStringHTML();
        super.onCreate(savedInstanceState);
        WebView view = new WebView(this);
        view.loadData(stringHtml,"text/html","UTF-8");
        view.getSettings().setJavaScriptEnabled(true);
        setContentView(view);*/

        super.onCreate(savedInstanceState);
        String[] vec = getResources().getStringArray(R.array.countries);
        StringBuffer sb = new StringBuffer();
        for(String str : vec)
        {
            sb.append(str);
            sb.append(" ");
        }
        TextView tv = new TextView(this);
        tv.setText(sb.toString());
        setContentView(tv);
    }

    private String getStringHTML()
    {
        StringBuffer sb = new StringBuffer();
        sb.append("<!DOCTYPE html>");
        sb.append("<html>");
        sb.append("<head lang=\"en\">");
        sb.append("    <meta charset=\"UTF-8\">");
        sb.append("    <title></title>");
        sb.append("</head>");
        sb.append("<body>");
        sb.append("<form action=\"http://www.abelski.com/courses/xhtml/bmi.php\" method=\"get\">");
        sb.append("    weight: <input type=\"text\" name=\"weight\" />");
        sb.append("    <br/>");
        sb.append("    height: <input type=\"text\" name=\"height\" />");
        sb.append("    <br/>");
        sb.append("    <input type=\"submit\" />");
        sb.append("</form>");
        sb.append("</body>");
        sb.append("</html>");
        return sb.toString();
    }
}
