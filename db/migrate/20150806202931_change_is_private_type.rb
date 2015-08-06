class ChangeIsPrivateType < ActiveRecord::Migration
  def change
    remove_column :users, :IsPrivate, :binary
    add_column :users, :IsPrivate, :boolean,  default: false
  end
end
