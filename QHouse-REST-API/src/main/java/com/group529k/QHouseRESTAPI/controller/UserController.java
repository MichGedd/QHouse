package com.group529k.QHouseRESTAPI.controller;

import com.group529k.QHouseRESTAPI.entity.User;
import com.group529k.QHouseRESTAPI.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;

@Controller
@RequestMapping("/users")
public class UserController {
    @Autowired
    private UserRepository userRepository;

    @PostMapping
    public @ResponseBody String createUser(@RequestBody User user)
    {
        userRepository.save(user);
        return "Added user";
    }
}
