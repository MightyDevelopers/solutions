class SessionsController < ApplicationController

  def new
  end

  def create
    user = User.find_by_Login(params[:Login])
    if user && user.authenticate(params[:Password])
        createSession user
        render json: user
    else
        render json: ["Invalid email/password combination"]
    end
  end

  def destroy
    destroySession
    render json: ["End of session"]
  end


end
