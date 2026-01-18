use std::{fs::{self}, io::{BufRead, BufReader}, time::SystemTime};

pub fn solution1(timer: &SystemTime){
    
    let file = fs::File::open("src/day2/input.txt").unwrap_or_else(|err|{
        println!("Should have been able to open the file: {}", err);
        std::process::exit(1);
    });

    let mut reader = BufReader::new(file);

    let mut input = String::new();
    let _ = reader.read_line(&mut input).unwrap_or_else(|err| {
        println!("Error reading file content: {err}");
        std::process::exit(1);
    });

    let input_range = input.split(",").map(String::from);
    let mut range : Vec<(i64, i64)> = Vec::new();
    for elem in input_range{
        let r: Vec<String> = elem.split("-").map(String::from).collect();
        let val1 : i64 = r[0].parse().unwrap();
        let val2 : i64 = r[1].parse().unwrap();
        range.push((val1, val2));
    }
    let mut invalid_ids :Vec<i64> = Vec::new();
    for r in range{
        for i in r.0..=r.1{
            let loop_value = i.to_string();
            let number_of_chars = loop_value.chars().count();
            if number_of_chars % 2 != 0{
                continue;
            }
            let first_part = &loop_value[..number_of_chars/2];
            let second_part = &loop_value[number_of_chars/2..];
            if first_part == second_part{
                invalid_ids.push(i);
            }
        }
    }

    let res : i64 = invalid_ids.iter().sum();
    let compute_time = timer.elapsed().unwrap().as_millis();
    println!("Res is {res}. Time to compute is {compute_time} ms")
}


pub fn solution2(timer : &SystemTime){
    
}