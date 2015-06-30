package il.ac.hit.model;

import java.io.Serializable;
import java.lang.Override;import java.lang.String;import java.util.Date;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;

/**
 * Created by User on 04/04/2015.
 */

@Entity
@Table(name="todoitems")
public class ToDoItem implements Serializable {

    @Id
    @GeneratedValue
    private int id;

    private String name;
    private String description;
    private Date startDate;
    private Date endDate;
    private Date creationDate;
    private String place;
    private int userID;

    public ToDoItem() {
        this(0,null,null,null,null,null,null,0);
    }

    public ToDoItem(int id, Date creationDate,int userID) {
        this(id,null,null,null,null,creationDate,null,userID);
    }

    public ToDoItem(int id, String name, Date creationDate,int userID) {
        this(id,name,null,null,null,creationDate,null,userID);
    }

    public ToDoItem(int id, String name, String description, Date creationDate,int userID) {
        this(id,name,description,null,null,creationDate,null,userID);
    }

    public ToDoItem(int id, String name, String description, Date startDate, Date endDate, Date creationDate,int userID) {
        this(id,name,description,startDate,endDate,creationDate,null,userID);
    }

    public ToDoItem(int id, String name, String description, Date startDate, Date endDate, Date creationDate, String place,int userID) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.startDate = startDate;
        this.endDate = endDate;
        this.creationDate = creationDate;
        this.place = place;
        this.userID = userID;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public Date getEndDate() {
        return endDate;
    }

    public void setEndDate(Date endDate) {
        this.endDate = endDate;
    }

    public Date getStartDate() {
        return startDate;
    }

    public void setStartDate(Date startDate) {
        this.startDate = startDate;
    }

    public Date getCreationDate() {
        return creationDate;
    }

    public void setCreationDate(Date creationDate) {
        this.creationDate = creationDate;
    }

    public String getPlace() {
        return place;
    }

    public void setPlace(String place) {
        this.place = place;
    }

    public int getUserID() {
        return userID;
    }

    public void setUserID(int userID) {
        this.userID = userID;
    }

    @Override
    public String toString() {
        return "id='" + id + '\'' +
                ", name='" + name + '\'' +
                ", description='" + description + '\'' +
                ", startDate=" + startDate +
                ", endDate=" + endDate +
                ", creationDate=" + creationDate +
                ", place='" + place;
    }
}
