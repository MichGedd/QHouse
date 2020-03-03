package com.group529k.QHouseRESTAPI.entity;

import javax.persistence.*;

@Entity
public class House {

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Integer id;

    @ManyToOne
    @JoinColumn
    private Landlord parentLandlord;

    private int numBedrooms;
    private int numBathrooms;


    public Landlord getParentLandlord() {
        return parentLandlord;
    }

    public void setParentLandlord(Landlord parentLandlord) {
        this.parentLandlord = parentLandlord;
    }

    public int getNumBedrooms() {
        return numBedrooms;
    }

    public void setNumBedrooms(int numBedrooms) {
        this.numBedrooms = numBedrooms;
    }

    public int getNumBathrooms() {
        return numBathrooms;
    }

    public void setNumBathrooms(int numBathrooms) {
        this.numBathrooms = numBathrooms;
    }
}
