<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class PedidosTemporales extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
      Schema::create('pedidos_temporales', function (Blueprint $table) {
          $table->integer('user_id');
          $table->integer('producto_id');
          $table->foreign('user_id')->references('id')->on('users');
          $table->foreign('producto_id')->references('id_producto')->on('inventarios');
          $table->integer('cantidad');
          $table->timestamps();
          $table->primary(['user_id', 'producto_id']);
      });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        //
    }
}
