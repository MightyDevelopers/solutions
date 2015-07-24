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
      @user = User.Get(params[:Login],params[:Password])
      if @user.empty?
        @message = ["Can't find this user"]
        json_return(@message)
      else
        json_return(@user)  
      end
    end
  end

  def updateProfile
    @message=[]
    if params[:Login].nil? || params[:Login].empty? 
      @message += ["Login can't be empty"] 
    end
    if params[:Email].nil? || params[:Email].empty? 
      @message += ["Email can't be empty"]
    end
    if params[:FirstName].nil? || params[:FirstName].empty? 
      @message += ["FirstName can't be empty"]
    end
    if params[:LastName].nil? || params[:LastName].empty? 
      @message += ["LastName can't be empty"]
    end
    if params[:ProfileImgPath].nil? || params[:ProfileImgPath].empty? 
      @message += ["ProfileImgPath can't be empty"]
    end
    if params[:Facebook].nil? || params[:Facebook].empty? 
      @message += ["Facebook can't be empty"]
    end
    if params[:Age].nil? || params[:Age].empty? 
      @message += ["Age can't be empty"]
    end
    if params[:Sex].nil? || params[:Sex].empty? 
      @message += ["Sex can't be empty"]
    end
    if params[:IsPrivate].nil? || params[:IsPrivate].empty? 
      @message += ["IsPrivate can't be empty"]
    end
    if !@message.empty?
      json_return(@message)  
    else 
      status = User.UpdateProfile(params[:Login],params[:Email],params[:FirstName],
                                  params[:LastName],params[:ProfileImgPath],params[:Facebook],
                                  params[:Age],params[:Sex],params[:IsPrivate])
      if status == 1
        @user = User.find(params[:Login])
        json_return(@user)  
      else
        @message =["Somesing wrong(maybe login is invalid)"]
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
    if params[:New_login].nil? || params[:New_login].empty? 
      @message += ["New_login can't be empty"]
    end
    if !@message.empty?
      json_return(@message)  
    else      
      status = User.UpdateLogin(params[:Login],params[:Password],params[:New_login])
      if status == 1 
        @user = User.Get(params[:New_login],params[:Password])
        json_return(@user)    
      else 
        @message = ["Somesing wrong(maybe login/password/new_login is invalid)"]    
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
    if params[:New_password].nil? || params[:New_password].empty? 
      @message += ["New_password can't be empty"]
    end
    if !@message.empty?
      json_return(@message)  
    else  
      status = User.UpdatePassword(params[:Login],params[:Password],params[:New_password])
      if status == 1 
        @user = User.Get(params[:Login],params[:New_password])
        json_return(@user)    
      else 
        @message = ["Somesing wrong(maybe login/password/new_password is invalid)"]    
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
      status = User.Delete(params[:Login],params[:Password])
      if status == 1
        @user = ["Deleted"]
        json_return(@user)
      else 
        @message = ["Somesing wrong(maybe login/password is invalid)"]
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
