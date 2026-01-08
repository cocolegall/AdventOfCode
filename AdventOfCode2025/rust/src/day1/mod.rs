use std::{time::SystemTime};


pub fn solution1(timer: &SystemTime){
    let input_content : Vec<String> = std::fs::read_to_string("src/day1/input.txt").unwrap_or_else(|err| {
        println!("Should have been able to read the file {err}");
        std::process::exit(1)
    }).lines().map(String::from).collect();

    let mut pos = 50;
    let mut res = 0;
    for elem in &input_content{
        if elem.is_empty(){
            continue;
        }
        let dir = elem.chars().nth(0).unwrap_or_else(|| 'X');
        let rot :i32 = elem[1..].parse().unwrap_or_else(|_| 0);
        let rot_real = rot % 100;
        if dir == 'R'{
            pos +=  rot_real;
            if pos > 99{
                pos = pos - 100;
            }
        }
        if dir == 'L'{
            pos -= rot_real;
            if pos < 0 {
                pos = 100 + pos;
            }
        }
        if pos == 0 {
            res += 1;
        }
    }

    let compute_time = timer.elapsed().unwrap().as_millis();
    println!("Final position is {pos} and the password is {res}, Time to compute {compute_time} ms")
}

pub fn solution2(timer: &SystemTime){
    let input_content : Vec<String> = std::fs::read_to_string("src/day1/input.txt").unwrap_or_else(|err| {
        println!("Should have been able to read the file {err}");
        std::process::exit(1)
    }).lines().map(String::from).collect();

    let mut pos = 50;
    let mut res = 0;
    for elem in &input_content{
        if elem.is_empty(){
            continue;
        }
        let dir = elem.chars().nth(0).unwrap_or_else(|| 'X');
        let rot :i32 = elem[1..].parse().unwrap_or_else(|_| 0);
        if dir == 'R'{
            let r_shift = pos + rot;
            if r_shift % 100 == 0{
                pos = 0;
                res += r_shift / 100;
                continue;
            }
            if r_shift > 0 {
                pos = r_shift - (100 * (r_shift/100));
                res += r_shift/100;
                continue;
            }
            pos = r_shift;
            continue;
        }
        if dir == 'L'{
            let num_click = rot / 100;
            res += num_click;
            let l_shift = pos - (rot - (100*(rot/100)));
            if l_shift == 0 {
                pos = l_shift;
                res +=1;
                continue;
            }
            if l_shift < 0 {
                if pos != 0 {
                    res += 1;
                }
                pos = 100 + l_shift;
                continue;
            }
            pos = l_shift;
            continue;
        }
    }

    let compute_time = timer.elapsed().unwrap().as_millis();
    println!("Final position is {pos} and the password is {res}, Time to compute {compute_time} ms")
}