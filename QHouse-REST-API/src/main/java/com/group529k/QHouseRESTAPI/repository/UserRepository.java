package com.group529k.QHouseRESTAPI.repository;

import com.group529k.QHouseRESTAPI.entity.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.BeanPropertyRowMapper;
import org.springframework.jdbc.core.namedparam.MapSqlParameterSource;
import org.springframework.jdbc.core.namedparam.NamedParameterJdbcTemplate;
import org.springframework.jdbc.core.namedparam.SqlParameterSource;
import org.springframework.stereotype.Repository;

@Repository
public class UserRepository {
    public static final String SQL_SAVE = "INSERT INTO users (NAME, PASSWORD) values(:name, :password)";

    public static final BeanPropertyRowMapper<User> ROW_MAPPER = new BeanPropertyRowMapper<>(User.class);

    @Autowired
    NamedParameterJdbcTemplate jdbcTemplate;

    public int save(User user)
    {
        final SqlParameterSource parameterSource = new MapSqlParameterSource()
                .addValue("name", user.getName())
                .addValue("password", user.getPassword());

        return jdbcTemplate.update(SQL_SAVE, parameterSource);
    }
}
