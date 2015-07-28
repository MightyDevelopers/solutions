class UsersController < ApplicationController
  respond_to :json

  def createUser
    @message=[]
    if params[:Login].nil? || params[:Login].empty? 
      @message += ["Login can't be empty"]
    elsif params[:Password].nil? || params[:Password].empty? 
      @message += ["Password can't be empty"]
    end
    if !@message.empty?
      json_return(@message)
    else
      @user = User.Insert(params[:Login],params[:Password])
      if @user.valid?
        sign_in @user
        @user = User.Get(params[:Login]).first
        json_return(@user)
      else json_return(@user.errors.full_messages)
      end
    end 
  end

  def getUser
    @message=[]
    if params[:Login].nil? || params[:Login].empty? 
      @message += ["Login can't be empty"]
    elsif params[:Password].nil? || params[:Password].empty? 
      @message += ["Password can't be empty"]
    end 
    if !@message.empty?
      json_return(@message)  
    else 
      @user = User.find_by_Login(params[:Login])
      if @user && @user.authenticate(params[:Password])
        @user=User.Get(params[:Login]).first
        sign_in @user
        json_return(@user)
      else
        @message += ["Can't find this user"]
        json_return(@message)
      end
    end
  end

  def updateProfile
    @message=[]
    if params[:Login].nil? || params[:Login].empty? 
      @message += ["Login can't be empty"] 
    end
    if params[:Email].nil? || params[:Email].empty? 
      params[:Email] = nil
    else 
      begin
        if EmailVerifier.check(params[:Email]) == false
          @message += ["Email not valid"]
        end
      rescue Exception => e
        @message += ["Email not valid"]
      end
    end
    if params[:FirstName].nil? || params[:FirstName].empty? 
      params[:FirstName] = nil
    end
    if params[:LastName].nil? || params[:LastName].empty? 
      params[:LastName] = nil
    end
    if params[:ProfileImgPath].nil? || params[:ProfileImgPath].empty? 
      params[:ProfileImgPath] = nil
    end
    if params[:Facebook].nil? || params[:Facebook].empty? 
      params[:Facebook] = nil
    end
    if params[:Age].nil? || params[:Age].empty? 
      params[:Age] = nil
    else 
      params[:Age]=params[:Age].to_i
      if params[:Age] <= 0
        @message += ["Age mast be numeric or > 0"]
      end
    end
    if params[:Sex].nil? || params[:Sex].empty? 
      params[:Sex] = nil
    elsif params[:Sex].length>1 || params[:Sex]!= "M" ||
          params[:Sex]!= "F" || params[:Sex]!= "N"
      params[:Sex] = nil
    end
    if params[:IsPrivate].nil? || params[:IsPrivate].empty? 
      params[:IsPrivate] = "\x00"
    elsif params[:IsPrivate] == "true"
      params[:IsPrivate] = "\x01"
    elsif params[:IsPrivate] == "false" 
      params[:IsPrivate] = "\x00"
    else params[:IsPrivate] = "\x00"
    end
    if !@message.empty?
      json_return(@message)  
    else 
      if sign_in?
        @user = User.find_by_Login(params[:Login])
        if @user
          User.UpdateProfile(params[:Login],params[:Email],params[:FirstName],
                      params[:LastName],params[:ProfileImgPath],params[:Facebook],
                      params[:Age],params[:Sex],params[:IsPrivate])
          @user = User.Get(params[:Login]).first
          json_return(@user)  
        else
          @message =["Somesing wrong(maybe login is invalid)"]
          json_return(@message)
        end
      else
        @message = ["You dont have permisions. Please sign in"]
        json_return(@message)
      end
    end
  end

  def changeLogin
    @message=[]
    if params[:Login].nil? || params[:Login].empty? 
      @message += ["Login can't be empty"]
    end
    if params[:Password].nil? || params[:Password].empty? 
      @message += ["Password can't be empty"]
    end
    if params[:New_login].nil? || params[:New_login].empty? ||
       params[:New_login] == params[:Login]
      @message += ["New_login invalid or empty"]
    end
    if !@message.empty?
      json_return(@message)  
    else      
      if sign_in?
        @user = User.find_by_Login(params[:Login])
        if @user && @user.authenticate(params[:Password])
          User.UpdateLogin(params[:Login],params[:New_login])
          @user = User.Get(params[:New_login]).first
          sign_in @user
          json_return(@user)    
        else 
          @message = ["Somesing wrong(maybe login/password/new_login is invalid)"]    
          json_return(@message)    
        end
      else
        @message = ["You dont have permisions. Please sign in"]
        json_return(@message)
      end
    end
  end

  def changePassword
    @message=[]
    if params[:Login].nil? || params[:Login].empty? 
      @message += ["Login can't be empty"]
    end
    if params[:Password].nil? || params[:Password].empty? 
      @message += ["Password can't be empty"]
    end
    if params[:New_password].nil? || params[:New_password].empty? ||
       params[:New_password].length < 6 || params[:Password]==params[:New_password]
      @message += ["New_password is invalid or to short"]
    end
    if !@message.empty?
      json_return(@message)  
    else  
      if sign_in?
        @user = User.find_by_Login(params[:Login])
        if @user && @user.authenticate(params[:Password])
          User.UpdatePassword(params[:Login],params[:New_password])
          @user = User.Get(params[:Login]).first
          json_return(@user)    
        else
          @message = ["Somesing wrong(maybe login/password/new_password is invalid)"]
          json_return(@message)
        end
      else
        @message = ["You dont have permisions. Please sign in"]
        json_return(@message)
      end
    end
  end

  def deleteUser
    @message=[]
    if params[:Login].nil? || params[:Login].empty? 
      @message += ["Login can't be empty"]
    end
    if params[:Password].nil? || params[:Password].empty? 
      @message += ["Password can't be empty"]
    end 
    if !@message.empty?
      json_return(@message)
    else
      if sign_in?
        @user = User.find_by_Login(params[:Login])
        if @user && @user.authenticate(params[:Password])
          User.Delete(params[:Login])
          @user = ["Deleted"]
          json_return(@user)
        else 
          @message = ["Somesing wrong(maybe login/password is invalid)"]
          json_return(@message)
        end
      else
        @message = ["You dont have permisions. Please sign in"]
        json_return(@message)        
      end
    end
  end

  def searchByName
    @message=[]
    if params[:Username].nil? || params[:Username].empty? 
      @message += ["Username can't be empty"]
    end 
    if !@message.empty?
      json_return(@message)
    else
      @user = User.SearchUsersByName(params[:Username])
      if @user.empty?
        @message = ["Can't find users whith this params"]
        json_return(@message)
      else
        json_return(@user)  
      end
    end
  end

  def json_return(param)
    render json: param
  end

end
