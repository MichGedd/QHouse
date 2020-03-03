package com.group529k.QHouseRESTAPI.entity;

import javax.persistence.*;
import java.util.List;
import java.util.Set;

@Entity
public class Landlord {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Integer id;
    private String name;
    private String password;
    private String email;

    @OneToMany(mappedBy = "parentLandlord", cascade = CascadeType.ALL)
    private Set<House> postedHouses;

    public Integer getId()
    {
        return id;
    }

    public void setId(Integer id)
    {
        this.id = id;
    }

    public String getName()
    {
        return name;
    }

    public void setName(String name)
    {
        this.name = name;
    }

    public String getPassword()
    {
        return password;
    }

    public void setPassword(String password)
    {
        this.password = password;
    }

    public Set<House> getPostedHouses() {
        return postedHouses;
    }

    public void setPostedHouses(Set<House> postedHouses) {
        this.postedHouses = postedHouses;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }
}
