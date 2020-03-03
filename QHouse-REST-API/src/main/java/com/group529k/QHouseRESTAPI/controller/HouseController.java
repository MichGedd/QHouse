package com.group529k.QHouseRESTAPI.controller;

import com.group529k.QHouseRESTAPI.entity.House;
import com.group529k.QHouseRESTAPI.entity.Landlord;
import com.group529k.QHouseRESTAPI.repository.HouseRepository;
import com.group529k.QHouseRESTAPI.repository.LandlordRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;

@Controller
@RequestMapping("/house")
public class HouseController {
    @Autowired
    private HouseRepository houseRepository;

    @Autowired
    private LandlordRepository landlordRepository;

    @PostMapping
    @RequestMapping(path = "/create")
    public String createHouse(@RequestParam Integer parentID, @RequestBody House house)
    {
        if(landlordRepository.findById(parentID).isPresent())
        {
            Landlord landlord = landlordRepository.findById(parentID).get();
            //landlord.getPostedHouses().add(house);
            house.setParentLandlord(landlord);
            return "Done";
        }

        return "Failed";
    }
}
