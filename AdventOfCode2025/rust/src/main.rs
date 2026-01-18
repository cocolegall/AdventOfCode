use std::{str::FromStr, time::SystemTime};

mod day1;
mod day2;

fn main() {
    let mut day = String::new();
    std::io::stdin().read_line(&mut day).expect("Should have been able to read from stdin");

    let timer = SystemTime::now();
    let day = day.trim();
    println!("Executing day {day}");
    match day{
        "1" => {day1::solution1(&timer); day1::solution2(&timer);},
        "2" => {day2::solution1(&timer);}
        _ => {println!("Day not found");return}
    }
    if let Ok(duration) = timer.elapsed(){
        let sec = duration.as_secs();
        println!("Time to compute day{day}: {sec} sec")
    } else {
        println!("Error calculating the time");
        return
    };
}
