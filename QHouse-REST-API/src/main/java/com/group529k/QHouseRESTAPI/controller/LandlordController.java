package com.group529k.QHouseRESTAPI.controller;

import com.group529k.QHouseRESTAPI.entity.Landlord;
import com.group529k.QHouseRESTAPI.repository.LandlordRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;

@Controller
@RequestMapping("/landlord")
public class LandlordController {
    @Autowired
    private LandlordRepository landlordRepository;

    @PostMapping
    @RequestMapping(path = "/create")
    public @ResponseBody
    String createStudent(@RequestBody Landlord landlord)
    {
        landlordRepository.save(landlord);
        return "Done";
    }

    @GetMapping
    @RequestMapping(path = "/login")
    public @ResponseBody String login(@RequestBody Landlord landlord)
    {
        for(Landlord l : landlordRepository.findAll())
        {
            if(l.getEmail().equals(landlord.getEmail()) && l.getPassword().equals(landlord.getPassword()))
            {
                return l.getId().toString();
            }
        }

        return "false";
    }

    @GetMapping
    public @ResponseBody Landlord getStudent(@RequestBody Integer id)
    {
        if(landlordRepository.findById(id).isPresent())
        {
            return landlordRepository.findById(id).get();
        }

        return null;
    }
}
