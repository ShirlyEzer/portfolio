package il.ac.hit.tagUtils;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.jsp.JspException;
import javax.servlet.jsp.JspWriter;
import javax.servlet.jsp.PageContext;
import javax.servlet.jsp.tagext.SimpleTagSupport;
import java.io.IOException;
import il.ac.hit.model.User;

/**
 * Created by User on 15/05/2015.
 */
public class LoginLogoutTag extends SimpleTagSupport {
    @Override
    public void doTag() throws JspException, IOException {
        super.doTag();
        PageContext pageContext = (PageContext) getJspContext();
        HttpServletRequest request = (HttpServletRequest) pageContext.getRequest();
        User user = (User) request.getSession().getAttribute("user");
        JspWriter out = getJspContext().getOut();
        if(user != null)
        {
            if(user.isLoggedIn() == false)
            {
                out.print("Login");
            }
            else
            {
                out.print("Logout");
            }
        }
        else
        {
            out.print("Login");
        }
    }
}
