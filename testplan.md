# Unit Tests on Backend
|Test Case ID|Description|
|------------|-----------|
|UT-001|Controller returns 400 BadRequest if Amount cannot be parsed|
|UT-002|Convert(decimal) returns "One dollar and ten cents." for 0.10|
|UT-003|Convert(decimal) returns "One dollar." for 1|
|UT-004|Convert(decimal) returns "Twelve dollars." for 12|
|UT-005|Convert(decimal) returns "One hundred and twenty-three dollars and forty-five cents." for 123.45|
|UT-006|Convert(decimal) returns "One thousand two hundred and thirty dollars and forty-five cents." for 1230.45|
|UT-007|Convert(decimal) returns "One million two hundred and thirty thousand dollars and forty-five cents." for 1230000.45|
|UT-008|Convert(decimal) returns "One billion two hundred and thirty million dollars and forty-five cents." for 1230000000.45|
|UT-009|Convert(decimal) returns "Negative one dollars and ten cents." for -1.1|
|UT-010|Convert(decimal) returns "Zero dollars." for 0|
|UT-011|Convert(decimal) returns "Zero dollars." for -0|
|UT-012|Convert(decimal) returns "Fifty-five cents." for 0.55|
|UT-013|Convert(decimal) returns "Negative fifty-five cents." for -0.55|
|UT-014|Convert(decimal) returns "One cent." for 0.01|
|UT-015|Convert(decimal) returns "Five cents." for 0.05|
