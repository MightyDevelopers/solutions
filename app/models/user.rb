class User < ActiveRecord::Base
  scope :GetUser, lambda { |login, password| 
    where(:Login => login , :Password => password ).first  }

  scope :InsertUser, lambda { |login, password| 
    create(:Login => login, :Password => password) }

  scope :UpdateUserPassword, lambda { |login, password|
    where(:Login => login).update_all(Password: password) }  
  
  scope :UpdateUserLogin, lambda { |login, password, newlogin|
    where(:Login => login, 
          :Password => password).update_all(Login: newlogin) }  
  
  scope :DeleteUser, lambda { |login, password|
    delete_all(:Login => login, :Password => password) }

  scope :UpdateUserProfile, lambda { |login, email, firstName,lastName, profileImgPath, facebook, age, sex, isPrivate|
    where(:Login => login).update_all(Email: email,
    FirstName: firstName, LastName: lastName, 
    ProfileImgPath: profileImgPath, Facebook: facebook, Age: age,
    Sex: sex, IsPrivate: isPrivate ) }
  
end
