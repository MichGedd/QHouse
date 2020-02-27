package com.group529k.QHouseRESTAPI.controller;

import com.group529k.QHouseRESTAPI.entity.Student;
import com.group529k.QHouseRESTAPI.repository.StudentRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;

@Controller
@RequestMapping("/students")
public class StudentController {
    @Autowired
    private StudentRepository studentRepository;

    @PostMapping
    public @ResponseBody String createStudent(@RequestBody Student student)
    {
        studentRepository.save(student);
        return "Done";
    }
}
