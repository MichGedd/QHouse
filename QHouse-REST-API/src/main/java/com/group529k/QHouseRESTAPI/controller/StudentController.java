package com.group529k.QHouseRESTAPI.controller;

import com.group529k.QHouseRESTAPI.entity.Student;
import com.group529k.QHouseRESTAPI.repository.StudentRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;

@Controller
@RequestMapping("/student")
public class StudentController {
    @Autowired
    private StudentRepository studentRepository;

    @PostMapping
    @RequestMapping(path = "/create")
    public @ResponseBody String createStudent(@RequestBody Student student)
    {
        studentRepository.save(student);
        return "Done";
    }

    @GetMapping
    @RequestMapping(path = "/login")
    public @ResponseBody String login(@RequestBody Student student)
    {
        for(Student s : studentRepository.findAll())
        {
            if(s.getEmail().equals(student.getEmail()) && s.getPassword().equals(student.getPassword()))
            {
                return s.getId().toString();
            }
        }

        return "false";
    }

    @GetMapping(value = "/{id}")
    public @ResponseBody Student getStudent(@PathVariable Integer id)
    {
        if(studentRepository.findById(id).isPresent())
        {
            return studentRepository.findById(id).get();
        }

        return null;
    }
}
