package com.company.Ex02;

import java.io.Serializable;

/**
 * Declare the class Student in order to describe a student.
 * The class should include the following attributes: privateName, familyName, id, tel and markAverage.
 * You should add methods and constructors as needed.
 * After declaring that class, Develop two applications.
 */
public class Student implements Serializable {

    private String privateName;
    private String familyName;
    private long id;
    private String tel;
    private double markAverage;

    public Student(String privateName, String familyName, long id, String tel, double markAverage) {
        this.privateName = privateName;
        this.familyName = familyName;
        this.id = id;
        this.tel = tel;
        this.markAverage = markAverage;
    }

    public String getPrivateName() {
        return privateName;
    }

    public void setPrivateName(String privateName) {
        this.privateName = privateName;
    }

    public String getFamilyName() {
        return familyName;
    }

    public void setFamilyName(String familyName) {
        this.familyName = familyName;
    }

    public String getTel() {
        return tel;
    }

    public void setTel(String tel) {
        this.tel = tel;
    }

    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public double getMarkAverage() {
        return markAverage;
    }

    public void setMarkAverage(double markAverage) {
        this.markAverage = markAverage;
    }

    @Override
    public String toString() {
        return "Student{" +
                "privateName='" + privateName + '\'' +
                ", familyName='" + familyName + '\'' +
                ", id=" + id +
                ", tel='" + tel + '\'' +
                ", markAverage=" + markAverage +
                '}';
    }
}
