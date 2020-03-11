package com.group529k.QHouseRESTAPI.controller;

import com.group529k.QHouseRESTAPI.entity.House;
import com.group529k.QHouseRESTAPI.entity.Landlord;
import com.group529k.QHouseRESTAPI.repository.HouseRepository;
import com.group529k.QHouseRESTAPI.repository.LandlordRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;

import javax.swing.text.html.Option;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;
import java.util.stream.Collectors;

@Controller
@RequestMapping("/house")
public class HouseController {
    @Autowired
    private HouseRepository houseRepository;

    @Autowired
    private LandlordRepository landlordRepository;

    @PostMapping
    @RequestMapping(path = "/create")
    public @ResponseBody String createHouse(@RequestParam Integer parentID, @RequestBody House house)
    {
        if(landlordRepository.findById(parentID).isPresent())
        {
            Landlord landlord = landlordRepository.findById(parentID).get();
            landlord.getPostedHouses().add(house);
            landlordRepository.save(landlord);

            //house.setParentLandlord(landlord);
            //houseRepository.save(house);
            return "Done";
        }

        return "Failed";
    }

    @GetMapping
    private @ResponseBody List<House> getAllHouses()
    {
        List<House> returnList = new ArrayList<>();
        houseRepository.findAll().forEach(returnList::add);
        return returnList;
    }

    @GetMapping
    private @ResponseBody List<House> getHouseWithParams(@RequestParam Optional<Integer> numBathrooms,
                                                         @RequestParam Optional<Integer> numBedrooms,
                                                         @RequestParam Optional<Double> minPrice,
                                                         @RequestParam Optional<Double> maxPrice)
    {
        List<House> returnList = new ArrayList<>();
        houseRepository.findAll().forEach(returnList::add);

        if(numBathrooms.isPresent())
        {
            returnList = returnList.stream().filter(n -> n.getNumBathrooms() >= numBathrooms.get()).collect(Collectors.toList());
        }

        if(numBedrooms.isPresent())
        {
            returnList = returnList.stream().filter(n -> n.getNumBedrooms() == numBedrooms.get()).collect(Collectors.toList());
        }

        if(minPrice.isPresent())
        {
            returnList = returnList.stream().filter(n -> n.getRent() >= minPrice.get()).collect(Collectors.toList());
        }

        if(maxPrice.isPresent())
        {
            returnList = returnList.stream().filter(n -> n.getRent() <= maxPrice.get()).collect(Collectors.toList());
        }

        return returnList;
    }
}
