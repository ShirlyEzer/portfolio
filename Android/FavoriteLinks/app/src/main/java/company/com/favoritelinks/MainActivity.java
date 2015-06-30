package company.com.favoritelinks;

import android.app.Activity;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;


public class MainActivity extends Activity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        final Intent intent = new Intent(Intent.ACTION_VIEW);
        setContentView(R.layout.activity_main);

        Button googleB = (Button)findViewById(R.id.btGoogle);

        googleB.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                intent.setData(Uri.parse("http://www.google.com"));
                startActivity(intent);

            }
        });

        Button hitB = (Button)findViewById(R.id.btHIT);

        hitB.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                intent.setData(Uri.parse("http://www.hit.ac.il"));
                startActivity(intent);

            }
        });

        Button youtubeB = (Button)findViewById(R.id.btYoutube);

        youtubeB.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                intent.setData(Uri.parse("http://www.youtube.com"));
                startActivity(intent);

            }
        });
    }
}
