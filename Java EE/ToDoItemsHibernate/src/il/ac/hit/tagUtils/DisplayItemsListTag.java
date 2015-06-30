package il.ac.hit.tagUtils;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.jsp.JspException;
import javax.servlet.jsp.JspWriter;
import javax.servlet.jsp.PageContext;
import javax.servlet.jsp.tagext.SimpleTagSupport;
import java.io.IOException;
import java.util.Date;
import java.util.List;
import il.ac.hit.model.ToDoItem;

/**
 *
 */
public class DisplayItemsListTag extends SimpleTagSupport {

    private String isExpired;

    public void setIsExpired(String msg) {
        this.isExpired = msg;
    }

    @Override
    public void doTag() throws JspException, IOException {
        super.doTag();
        String str = (isExpired == "true") ? "c" : "a";
        PageContext pageContext = (PageContext) getJspContext();
        HttpServletRequest request = (HttpServletRequest) pageContext.getRequest();
        JspWriter out = getJspContext().getOut();
        List<ToDoItem> list = (List<ToDoItem>)request.getSession().getAttribute("todoitems");
        for (int i = 0; i < list.size(); i++) {
            if(list.get(i).getEndDate().before(new Date()))
            {
                out.print(printWithSpecifiedTheme(str,list.get(i)));
            }
            else
            {
                out.print(printWithSpecifiedTheme("a",list.get(i)));
            }
        }
    }

    private String printWithSpecifiedTheme(String theme, ToDoItem item)
    {
        StringBuffer stringBuffer = new StringBuffer();
        stringBuffer.append("<div data-theme=\"" + theme + "\" " +
                "data-content-theme=\"" + theme + "\" " +
                "data-role=\"collapsible\" " +
                "data-collapsed=\"true\" " +
                "data-collapsed-icon=\"arrow-r\" " +
                "data-expanded-icon=\"arrow-d\" " +
                "data-iconpos=\"left\">");
        stringBuffer.append("<h3>" + item.getName() + "</h3>");
        stringBuffer.append("<p>Description: "+  item.getDescription() + "</p>");
        stringBuffer.append("<p>Start Date: "+  item.getStartDate() + "</p>");
        stringBuffer.append("<p>End Date: "+  item.getEndDate() + "</p>");
        stringBuffer.append("<p>Creation Date: "+  item.getCreationDate() + "</p>");
        stringBuffer.append("<p>Place: "+  item.getPlace() + "</p>");
        stringBuffer.append("<form ACTION=\"/doitsimple/delete_todo_item\" method=\"get\">");
        stringBuffer.append("<input type=\"hidden\" name=\"did\" id=\"did\" value=\"" + item.getId()+ "\">");
        stringBuffer.append("<input class=\"ui-btn ui-btn-"+theme+"\" data-theme=\"" + theme + "\" " + " type=\"submit\" value=\"Delete!\" data-icon=\"delete\">");
        stringBuffer.append("</form>");
        stringBuffer.append("<form ACTION=\"/doitsimple/update_attempt\" method=\"get\">");
        stringBuffer.append("<input type=\"hidden\" name=\"uid\" id=\"uid\" value=\"" + item.getId()+ "\">");
        stringBuffer.append("<input class=\"ui-btn ui-btn-"+theme+"\" data-theme=\"" + theme + "\" " + "type=\"submit\" value=\"Update!\" data-icon=\"back\">");
        stringBuffer.append("</form>");
        stringBuffer.append("<br/>");
        stringBuffer.append("<br/>");
        stringBuffer.append("</div>");
        return stringBuffer.toString();
    }
}
